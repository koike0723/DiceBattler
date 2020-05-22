using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDice : MonoBehaviour
{
	private SpriteRenderer _srenderer = default;
	public bool isContact = default;
	
    // Start is called before the first frame update
    void Start()
    {
		_srenderer = GetComponent<SpriteRenderer>();
		isContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			_srenderer.color = new Color32(159, 164, 250, 255);
			isContact = true;
		}
	}
}
