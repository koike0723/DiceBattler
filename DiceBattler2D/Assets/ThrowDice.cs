using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowDice : MonoBehaviour
{
	private Vector2 init_pos = Vector2.zero;
	private Vector2 touchStartPos;
	private Vector2 touchEndPos;
	[SerializeField] private float move_val = 30.0f;

	public float min_pow = 0.5f;
	public float max_pow = 3.0f;
	[SerializeField] private float pow_gauge_speed = 0.1f;
	private bool up_flg = true;
	public float throw_pow = 0.0f;

	public void Throw(Vector2 dir)
	{
		GetComponent<Rigidbody2D>().AddForce(dir);
	}

	void ThrowPower()
	{
		if(up_flg == true)
		{
			throw_pow += pow_gauge_speed;
			if(throw_pow >= max_pow)
			{
				up_flg = false;
			}
		}
		else
		{
			throw_pow -= pow_gauge_speed;
			if(throw_pow <= min_pow)
			{
				up_flg = true;
			}
		}

	}


	void ThrowDirection()
	{
		float dirX = touchEndPos.x - touchStartPos.x;
		float dirY = touchEndPos.y - touchStartPos.y;

		if (Mathf.Abs(dirX) < move_val && Mathf.Abs(dirY) < move_val)
		{
			GetComponent<Transform>().position = init_pos;
			throw_pow = min_pow;
		}
		else
		{
			Throw(new Vector2(dirX, dirY).normalized * throw_pow);
		}
		
	}

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
			ThrowPower();
			//Debug.Log("test");
		}

		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			touchEndPos = new Vector2(Input.mousePosition.x,
									Input.mousePosition.y);
			
			ThrowDirection();
		}

	}



	// Start is called before the first frame update
	void Start()
	{
		init_pos = GetComponent<Transform>().position;
		throw_pow = min_pow;
	}

    // Update is called once per frame
    void Update()
    {
		Flick();
    }
}
