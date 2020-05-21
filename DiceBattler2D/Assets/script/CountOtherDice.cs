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

	public int Count()
	{
		var clones = GameObject.FindGameObjectsWithTag("other_dice");
		foreach (var clone in clones)
		{
			other_dice_count++;
			Debug.Log(other_dice_count);
		}
		return other_dice_count;
	}

	public void Reset()
	{
		other_dice_count = 0;
	}
}
