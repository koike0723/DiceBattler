using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCircle : MonoBehaviour
{
	private GameObject parent = default;
	private Rigidbody2D _rigidbody2D = default;
	private DiceFace _diceface = default;
	public int del_dice_num = 0;
	public int dice_element_val = 0;

    // Start is called before the first frame update
    void Start()
    {
		parent = transform.parent.gameObject;
		_rigidbody2D = parent.GetComponent<Rigidbody2D>();
		_diceface = parent.GetComponent<DiceFace>();
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.CompareTag("other_dice"))
		{
			if(_rigidbody2D.velocity.normalized.magnitude == 0)
			{
				if(collision.GetComponent<DiceFace>().GetElementVal() ==
					_diceface.GetElementVal())
				{
					collision.GetComponent<SpriteRenderer>().color = Color.yellow;
					dice_element_val = _diceface.GetElementVal();
					DeleteDice(collision.gameObject);
				}
				
			}
			
		}
	}

	private void DeleteDice(GameObject obj)
	{
		Destroy(obj);
		del_dice_num += 1;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("other_dice"))
		{
			//collision.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}
