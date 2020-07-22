using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeDiceNum : MonoBehaviour
{
    [SerializeField]
    private GameObject _NoticeDice = default;
    private DiceStatus _diceface = default;

    //x:0～1,y:0～5.99
    [SerializeField]
    private AnimationCurve curve_face = default;
	//高速面変化フレーム
	[SerializeField]
	private int frame_num_high = 15;
	//低速面変化フレーム
	[SerializeField]
	private int frame_num_low = 100;
	//フレーム数
	private int frame_cnt = 0;
	//フレーム数
	[SerializeField]
	private int frame_cnt_line_1 = 60;
	//フレーム数
	[SerializeField]
	private int frame_cnt_line_2 = 90;
	//サイコロの面番号
	private int face_element_num = 0;

	private bool is_stop = default;

    // Start is called before the first frame update
    void Start()
    {
        _diceface = _NoticeDice.GetComponent<DiceStatus>();
		is_stop = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(!is_stop)
		{
			Randomize();
			frame_cnt++;
		}
    }

	public void Randomize()
	{
		if (frame_cnt < frame_cnt_line_1)
		{
			if (frame_cnt % frame_num_high == 0)
			{
				face_element_num = (int)CurveWaighteRandom(curve_face);
			}
		}
		else if (frame_cnt < frame_cnt_line_2)
		{
			if (frame_cnt % frame_num_low == 0)
			{
				face_element_num = (int)CurveWaighteRandom(curve_face);
			}
		}
		else if(frame_cnt >= frame_cnt_line_2)
		{
			frame_cnt = 0;
			is_stop = true;
		}
		_diceface.SetSprite(face_element_num);
	}

	public float CurveWaighteRandom(AnimationCurve curve)
    {
        return curve.Evaluate(Random.value);
    }
}
