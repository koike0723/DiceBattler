using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDice : MonoBehaviour
{
	private SpriteRenderer _srenderer = default;
	public bool is_contact = default;
	public bool is_stay_area = default;
	
    // Start is called before the first frame update
    void Start()
    {
		_srenderer = GetComponent<SpriteRenderer>();
		is_contact = false;
		is_stay_area = false;

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
			is_contact = true;
		}
	}
}
