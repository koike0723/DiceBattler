using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCIrcle : MonoBehaviour
{
	private GameObject parent = default;
	private Rigidbody2D _rigidbody2D = default;

    // Start is called before the first frame update
    void Start()
    {
		parent = transform.parent.gameObject;
		_rigidbody2D = parent.GetComponent<Rigidbody2D>();
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
				collision.GetComponent<SpriteRenderer>().color = Color.yellow;
			}
			
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("other_dice"))
		{
			collision.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}
