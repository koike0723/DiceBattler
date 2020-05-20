using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowDice : MonoBehaviour
{
	//初期化用位置
	private Vector2 init_pos = Vector2.zero;
	//指を置いた位置
	private Vector2 touchStartPos;
	//指を離した位置
	private Vector2 touchEndPos;

	private Vector2 touchNowPos;
	public Vector2 swipeVec;
	//スワイプ判定の基準値
	[SerializeField]
	private float move_val = 30.0f;

	//投擲パワー最低値
	public float min_pow = 0.5f;
	//投擲パワー最大値
	public float max_pow = 3.0f;
	//パワーの上昇値
	[SerializeField]
	private float pow_up_val = 0.1f;

	//高速度基準値
	[SerializeField]
	private float high_verocity_val = 5.0f;
	//低速度基準値
	[SerializeField]
	private float low_verocity_val = 0.0005f;
	//高速面変化フレーム
	[SerializeField]
	private int frame_num_high = 15;
	//低速面変化フレーム
	[SerializeField]
	private int frame_num_low = 100;
	

	//パワーゲージの最大値を超えたか判定用
	private bool up_flg = true;
	//投擲パワー値
	public float throw_pow = 0.0f;

	private Transform _transform;
	private Rigidbody2D _rigdbody2D;
	private DiceFace _diceface;
	private AreaCircle _areacircle;

	//サイコロの面番号
	private int face_element_num = 0;
	//フレーム数
	private int frame_cnt = 0;

	// Start is called before the first frame update
	void Start()
	{
		//各種コンポーネント取得
		_transform = GetComponent<Transform>();
		_rigdbody2D = GetComponent<Rigidbody2D>();
		_diceface = GetComponent<DiceFace>();
		_areacircle = GetComponentInChildren<AreaCircle>();
		//初期化用位置に現在値を入れる
		init_pos = _transform.position;
		//投擲パワーを最低値に
		throw_pow = min_pow;
	}

	// Update is called once per frame
	void Update()
	{
		//サイコロの面番号から表示する画像を選択
		_diceface.SetSprite(CreateElementNum());

		//フリック処理
		Flick();

	}

	//サイコロの面番号をランダムに生成
	public int CreateElementNum()
	{
		frame_cnt += 1;
		if (_rigdbody2D.velocity.magnitude > high_verocity_val || Input.GetKey(KeyCode.Mouse0))
		{
			if (frame_cnt % frame_num_high == 0)
			{
				face_element_num = Random.Range(0, DiceFace.face_num * 100) % DiceFace.face_num;
			}
		}
		else if (_rigdbody2D.velocity.magnitude > low_verocity_val)
		{
			if (frame_cnt % frame_num_low == 0)
			{
				face_element_num = Random.Range(0, DiceFace.face_num * 100) % DiceFace.face_num;
			}
		}
		else
		{
			frame_cnt = 0;
			_rigdbody2D.velocity = Vector2.zero;
		}

		return face_element_num;
	}

	//投擲処理
	public void Throw(Vector2 dir)
	{
		_rigdbody2D.AddForce(dir);
	}

	//投擲パワー上昇処理
	void ThrowPower()
	{
		if(up_flg == true)
		{
			throw_pow += pow_up_val;
			if(throw_pow >= max_pow)
			{
				up_flg = false;
			}
		}
		else
		{
			throw_pow -= pow_up_val;
			if(throw_pow <= min_pow)
			{
				up_flg = true;
			}
		}
	}

	//投擲方向決定処理
	void ThrowDirection()
	{
		float dirX = touchEndPos.x - touchStartPos.x;
		float dirY = touchEndPos.y - touchStartPos.y;

		swipeVec = new Vector2(dirX, dirY);

		if (Mathf.Abs(dirX) < move_val && Mathf.Abs(dirY) < move_val)
		{
			ResetDice();
		}
		else
		{
			Throw(swipeVec.normalized * throw_pow);
		}
	}

	//サイコロ初期化処理
	void ResetDice()
	{
		_transform.position = init_pos;
		_transform.rotation = new Quaternion(0, 0, 0, 0);
		_rigdbody2D.velocity = Vector2.zero;
		throw_pow = min_pow;
		face_element_num = 0;
	}

	//フリック操作処理
	void Flick()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			touchStartPos = new Vector2(Input.mousePosition.x,
										Input.mousePosition.y);
			throw_pow = min_pow;
		}

		if(Input.GetKey(KeyCode.Mouse0))
		{
			touchNowPos = new Vector2(Input.mousePosition.x,
										Input.mousePosition.y);
			float dirX = touchNowPos.x - touchStartPos.x;
			float dirY = touchNowPos.y - touchStartPos.y;

			swipeVec = new Vector2(dirX, dirY);
			ThrowPower();
		}

		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			touchEndPos = new Vector2(Input.mousePosition.x,
									Input.mousePosition.y);
			
			ThrowDirection();
			_areacircle.enabled = true;
		}
	}

}
