using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AreaCircle : MonoBehaviour
{
	private GameObject parent = default;
	private Rigidbody2D _rigidbody2D = default;
	private DiceStatus _diceface = default;
	public int del_dice_num = 0;
	public int dice_element_val = 0;
	public bool is_action = default;

    // Start is called before the first frame update
    void Start()
    {
		parent = transform.parent.gameObject;
		_rigidbody2D = parent.GetComponent<Rigidbody2D>();
		_diceface = parent.GetComponent<DiceStatus>();
		is_action = false;
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	private void OnTriggerStay2D(Collider2D other_dice)
	{
		if(other_dice.CompareTag("other_dice"))
		{
			if(_rigidbody2D.velocity.normalized.magnitude == 0)
			{
				if(other_dice.GetComponent<DiceStatus>().GetElementVal() == _diceface.GetElementVal())
				{
					dice_element_val = _diceface.GetElementVal();
					DeleteDiceIsContact();
					DeleteDice(other_dice.gameObject);
					is_action = true;
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other_dice)
	{
		if(other_dice.CompareTag("other_dice"))
		{
			other_dice.GetComponent<ContactDice>().is_stay_area = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other_dice)
	{
		if (other_dice.CompareTag("other_dice"))
		{
			other_dice.GetComponent<ContactDice>().is_stay_area = false;
		}
	}

	private void DeleteDiceIsContact()
	{
		var clones = GameObject.FindGameObjectsWithTag("other_dice");
		foreach (var clone in clones)
		{
			var _dice = clone.GetComponent<ContactDice>();
			if (_dice.is_contact && _dice.is_stay_area)
			{
				Destroy(clone);
				del_dice_num += 1;
			}
		}
	}

	private void DeleteDice(GameObject obj)
	{
		Destroy(obj);
		del_dice_num += 1;
	}
}
