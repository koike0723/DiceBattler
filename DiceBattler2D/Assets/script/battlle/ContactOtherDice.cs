using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactOtherDice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("other_dice"))
		{
			collision.gameObject.GetComponent<SpriteRenderer>().color = new Color32(159, 164, 250, 255);
			collision.gameObject.GetComponent<ContactDice>().is_contact = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("other_dice"))
		{
			collision.gameObject.GetComponent<SpriteRenderer>().color = new Color32(159, 164, 250, 255);
			collision.gameObject.GetComponent<ContactDice>().is_contact = true;
		}
	}
}
