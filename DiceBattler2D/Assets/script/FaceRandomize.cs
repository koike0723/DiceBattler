using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRandomize: MonoBehaviour
{
	public AnimationCurve curve_face = default;

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
	//フレーム数
	private int frame_cnt = 0;
	//サイコロの面番号
	private int face_element_num = 0;

	private Rigidbody2D _rigidbody2D = default;
	private DiceStatus _diceface = default;

	private bool is_first = default;

	// Start is called before the first frame update
	void Start()
    {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_diceface = GetComponent<DiceStatus>();
		frame_cnt = 0;
		is_first = true;

	}

    // Update is called once per frame
    void Update()
    {
		if(is_first)
		{
			Randomize();
		}
		frame_cnt += 1;
	}

	public void Randomize()
	{
		if (_rigidbody2D.velocity.magnitude > high_verocity_val)
		{
			if (frame_cnt % frame_num_high == 0)
			{
				face_element_num = (int)CurveWaighteRandom(curve_face);
			}
		}
		else if (_rigidbody2D.velocity.magnitude > low_verocity_val)
		{
			if (frame_cnt % frame_num_low == 0)
			{
				face_element_num = (int)CurveWaighteRandom(curve_face);
			}
		}
		else
		{
			if(frame_cnt >= 10)
			{
				frame_cnt = 0;
				_rigidbody2D.velocity = Vector2.zero;
				is_first = false;
			}
		}
		_diceface.SetSprite(face_element_num);
	}

	public float CurveWaighteRandom(AnimationCurve curve)
	{
		return curve.Evaluate(Random.value);
	}
}
