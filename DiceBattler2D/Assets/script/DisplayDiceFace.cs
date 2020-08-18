using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDiceFace : MonoBehaviour
{

	private DiceStatus _diceStatus = default;
	private Rigidbody2D _rigdbody2D = default;

	//x:0～1,y:0～5.99
	[SerializeField]
	private AnimationCurve curve_face = default;

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

	//サイコロの面番号
	private int face_element_num = 0;
	//フレーム数
	private int frame_cnt = 0;

	private void Awake()
	{
		_diceStatus = GetComponent<DiceStatus>();
		_rigdbody2D = transform.parent.GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //サイコロの面番号から表示する画像を選択
        _diceStatus.SetSprite(CreateElementNum());
    }

	private void OnDisable()
	{
		frame_cnt = 0;
		face_element_num = 0;
		_diceStatus.SetSprite(face_element_num);
	}

	public int CreateElementNum()
	{
		//サイコロの速さで面が変化するスピードが変わる
		frame_cnt += 1;
		if (_rigdbody2D.velocity.magnitude > high_verocity_val || Input.GetKey(KeyCode.Mouse0))
		{
			if (frame_cnt % frame_num_high == 0)
			{
				face_element_num = (int)CurveWaighteRandom(curve_face);
			}
		}
		else if (_rigdbody2D.velocity.magnitude > low_verocity_val)
		{
			if (frame_cnt % frame_num_low == 0)
			{
				face_element_num = (int)CurveWaighteRandom(curve_face);
			}
		}
		else if (_rigdbody2D.velocity.magnitude < low_verocity_val)
		{
			frame_cnt = 0;
			_rigdbody2D.velocity = Vector2.zero;
		}

		return face_element_num;
	}

	//アニメーションカーブに設定したyの範囲内の数値をランダムで返す
	public float CurveWaighteRandom(AnimationCurve curve)
	{
		return curve.Evaluate(Random.value);
	}
}
