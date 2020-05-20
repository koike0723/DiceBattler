using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountOtherDice: MonoBehaviour
{
	public int other_dice_count;

    // Start is called before the first frame update
    void Start()
    {
		other_dice_count = 0;

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("other_dice"))
		{
			other_dice_count++;
			Debug.Log(other_dice_count);
		}
	}

	private void OnDisable()
	{
		other_dice_count = 0;
	}
}
