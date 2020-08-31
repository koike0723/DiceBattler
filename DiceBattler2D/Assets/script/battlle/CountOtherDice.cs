using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountOtherDice: MonoBehaviour
{
	private DiceStatus _diceStatus = default;
	private List<GameObject> m_OtherDice = default;

	public int other_dice_count = default;

	// Start is called before the first frame update
	void Start()
    {
		_diceStatus = this.GetComponent<DiceStatus>();
		other_dice_count = 0;

		m_OtherDice = new List<GameObject>();
	}

	// Update is called once per frame
	void Update()
    {
       
    }

	public int Count()
	{
		var clones = GameObject.FindGameObjectsWithTag("other_dice");
		foreach (var clone in clones)
		{
			var status = clone.GetComponent<DiceStatus>();
			if (status.GetElementVal() == _diceStatus.GetElementVal())
			{
				m_OtherDice.Add(clone);
			}
		}
		other_dice_count = m_OtherDice.Count;

		return other_dice_count;
	}

	public void DelOtherDice()
	{ 
		foreach(var dice in m_OtherDice)
		{
			var contact = dice.GetComponent<ContactDice>();
			if(!contact.is_contact)
			{
				dice.GetComponent<PlayOtherDiceEffect>().PlayLightBall();
			}
			else
			{
				dice.GetComponent<PlayOtherDiceEffect>().PlayHexShield();
				other_dice_count--;
			}
		}
		m_OtherDice.Clear();
	}
}
