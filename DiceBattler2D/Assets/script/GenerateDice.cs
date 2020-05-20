using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDice : MonoBehaviour
{
	[SerializeField]
	private GameObject other_dice = default;
	[SerializeField]
	private GameObject other_dice_counter = default;

	public int set_dice_max = 5;
	private int other_dice_num = 0;

    // Start is called before the first frame update
    void Start()
    {
		Generate(set_dice_max);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
			other_dice_counter.SetActive(true);
			
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			if(other_dice_counter.activeSelf == true)
			{
				other_dice_num =
				other_dice_counter.GetComponent<CountOtherDice>().other_dice_count;
				other_dice_counter.SetActive(false);
			}
		}
		Generate(set_dice_max - other_dice_num);

		if(Input.GetKey(KeyCode.KeypadEnter))
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
			x_pos = Random.Range(-2.00f, 2.00f);
			y_pos = Random.Range(-2.00f, 3.40f);
			other_dice_pos = new Vector3(x_pos, y_pos, 0);
			Instantiate(other_dice, other_dice_pos, Quaternion.identity);
		}
		other_dice_num = set_dice_max;
	}

	public void Delete()
	{
		var clones = GameObject.FindGameObjectsWithTag("other_dice");
		foreach(var clone in clones)
		{
			Destroy(clone);
		}
		
	}
}
