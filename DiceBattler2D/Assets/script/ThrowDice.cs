using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDice : MonoBehaviour
{
	//初期化用位置
	private Vector2 init_pos = Vector2.zero;
	//指を置いた位置
	private Vector2 touch_start_pos = Vector2.zero;
	//指を離した位置
	private Vector2 touch_end_pos = Vector2.zero;
	//指の現在位置
	private Vector2 touch_now_pos = Vector2.zero;
	//スワイプ方向
	private Vector2 swipe_vec = Vector2.zero;
	public Vector2 swipeVec
	{
		get
		{
			return swipe_vec;
		}
	}
	//スワイプ判定の基準値
	[SerializeField]
	private float move_val = 30.0f;
	//投擲方向右限界値
	[SerializeField]
	private float angle_limit_right = 30.0f;
	//投擲方向左限界値
	[SerializeField]
	private float angle_limit_left = 150.0f;

	//投擲パワー最低値
	[SerializeField]
	private float min_pow = 60f;
	public float minPow
	{
		get
		{
			return min_pow;
		}
	}
	//投擲パワー最大値
	[SerializeField]
	private float max_pow = 120.0f;
	public float maxPow
	{
		get
		{
			return max_pow;
		}
	}
	//パワーの上昇値
	[SerializeField]
	private float pow_up_val = 1.0f;


	//パワーゲージの最大値を超えたか判定用
	private bool is_max = true;
	//投擲パワー値
	private float throw_pow = 0.0f;
	public float thorowPow
	{
		get
		{
			return throw_pow;
		}
	}

	private GameObject _AreaCircle = default;
	private Transform _transform = default;
	private Rigidbody2D _rigidbody2D = default;
	private Collider2D _collider2D = default;
	private CheckThrowingDice _checkThrowing = default;


	private void Awake()
	{
		//各種コンポーネント取得
		_AreaCircle = transform.parent.transform.Find("area_circle").gameObject;
		_transform = GetComponent<Transform>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_collider2D = GetComponent<Collider2D>();
		_checkThrowing = GetComponent<CheckThrowingDice>();
		//初期化用位置に現在値を入れる
		init_pos = _transform.position;
		//投擲パワーを最低値に
		throw_pow = min_pow;
	}
	// Start is called before the first frame update
	void Start()
	{
	}

	private void OnEnable()
	{
		//フリック処理(スクリプト有効化時クリック位置取得)
		Flick();
	}

	// Update is called once per frame
	void Update()
	{
		//フリック処理
		Flick();
	}

	private void FixedUpdate()
	{
		
	}

	//投擲処理
	public void Throw(Vector2 dir)
	{
		_rigidbody2D.AddForce(dir, ForceMode2D.Impulse);
		_checkThrowing.SetVariable(VariavleName.isThrow);

	}

	//投擲パワー上昇処理
	void ThrowPower()
	{
		if (is_max == true)
		{
			throw_pow += pow_up_val;
			if (throw_pow >= max_pow)
			{
				is_max = false;
			}
		}
		else
		{
			throw_pow -= pow_up_val;
			if (throw_pow <= min_pow)
			{
				is_max = true;
			}
		}
	}

	//投擲方向限界設定処理
	void DirectionLimit(float dirx, float diry)
	{
		var vec = new Vector2(dirx, diry);
		var angle = Vector2.Angle(transform.right, vec);
		float rad = default;

		if(diry > 0)
		{
			swipe_vec = vec;
			if (angle <= angle_limit_right)
			{
				angle = angle_limit_right;
				rad = (angle * Mathf.Deg2Rad);
				swipe_vec = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
			}
			if (angle >= angle_limit_left)
			{
				angle = angle_limit_left;
				rad = (angle * Mathf.Deg2Rad);
				swipe_vec = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
			}
		}
		if(diry == 0 && dirx == 0)
		{
			swipe_vec = Vector2.up;
		}
	}

	//投擲方向決定処理
	void ThrowDirection()
	{
		float dir_x = touch_end_pos.x - touch_start_pos.x;
		float dir_y = touch_end_pos.y - touch_start_pos.y;

		DirectionLimit(dir_x,dir_y);

		if (dir_y <= 0)
		{
			ResetDice();
		}
		else
		{
			if (Mathf.Abs(dir_x) < move_val && Mathf.Abs(dir_y) < move_val)
			{
				ResetDice();
			}
			else
			{
				Throw(swipe_vec.normalized * throw_pow);
				_AreaCircle.GetComponent<Collider2D>().enabled = true;
			}
		}
		
	}

	//サイコロ初期化処理
	void ResetDice()
	{
		_transform.position = init_pos;
		_transform.rotation = new Quaternion(0, 0, 0, 0);
		_rigidbody2D.velocity = Vector2.zero;
		throw_pow = min_pow;
		swipe_vec = Vector2.up;
		_checkThrowing.SetVariable(VariavleName.isCancel);
	}

	//フリック操作処理
	void Flick()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			_AreaCircle.GetComponent<Collider2D>().enabled = false;
			_collider2D.isTrigger = true;
			touch_start_pos = new Vector2(Input.mousePosition.x,
										Input.mousePosition.y);
			throw_pow = min_pow;
		}

		if (Input.GetKey(KeyCode.Mouse0))
		{
			touch_now_pos = new Vector2(Input.mousePosition.x,
										Input.mousePosition.y);
			float dirX = touch_now_pos.x - touch_start_pos.x;
			float dirY = touch_now_pos.y - touch_start_pos.y;

			DirectionLimit(dirX, dirY);

			ThrowPower();
		}

		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			touch_end_pos = new Vector2(Input.mousePosition.x,
									Input.mousePosition.y);

			ThrowDirection();
		}
	}
	
	//フィールド内に入る時自身のtrigger判定を解除
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("in_field"))
		{
			_collider2D.isTrigger = false;
		}
	}
}
