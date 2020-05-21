using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDice : MonoBehaviour
{
	[SerializeField]
	private GameObject _other_dice_prefab = default;
	[SerializeField]
	private GameObject _other_dice_counter = default;

	private CountOtherDice _count = default;

	public AnimationCurve curve_x = default;
	public AnimationCurve curve_y = default;
	public AnimationCurve curve_pow = default;

	private float throw_pow = default;

	public int set_dice_max = 5;
	private int other_dice_num = 0;

	

	// Start is called before the first frame update
	void Start()
    {
		_count = _other_dice_counter.GetComponent<CountOtherDice>();
		Generate(set_dice_max);
		Throw();
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
			other_dice_num = _count.Count();
			if(set_dice_max > other_dice_num)
			{
				Generate(set_dice_max - other_dice_num);
				Throw();
			}
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			_count.Reset();
		}
		if (Input.GetKey(KeyCode.KeypadEnter))
		{
			Delete();
		}

    }

	public void Generate(int dice_num)
	{
		float x_pos = 0;
		float y_pos = 0;
		Vector3 other_dice_pos = Vector3.zero;
		for (int i = 1; i <= dice_num; i++)
		{
			x_pos = CurveWaighteRandom(curve_x);
			y_pos = CurveWaighteRandom(curve_y);
			other_dice_pos = new Vector3(x_pos, y_pos, 0);
			Instantiate(_other_dice_prefab, other_dice_pos, Quaternion.identity);
		}
		other_dice_num = set_dice_max;
	}

	public void Throw()
	{
		Vector2 pos = Vector2.zero;
		Vector2 dir = Vector2.zero;
		var clones = GameObject.FindGameObjectsWithTag("other_dice");
		foreach (var clone in clones)
		{
			var now_pos = clone.GetComponent<Transform>().position;
			pos.x = CurveWaighteRandom(curve_x) - now_pos.x;
			pos.y = CurveWaighteRandom(curve_y) - now_pos.y;
			dir = pos;
			throw_pow = CurveWaighteRandom(curve_pow);
			clone.GetComponent<Rigidbody2D>().AddForce(dir.normalized * throw_pow);
		}
	}

	public void Delete()
	{
		var clones = GameObject.FindGameObjectsWithTag("other_dice");
		foreach(var clone in clones)
		{
			Destroy(clone);
		}
		
	}

	public float CurveWaighteRandom(AnimationCurve curve)
	{
		return curve.Evaluate(Random.value);
	}

}
