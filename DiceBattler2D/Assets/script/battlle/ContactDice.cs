using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDice : MonoBehaviour
{
	public bool is_contact = default;
	public bool is_stay_area = default;
	
    // Start is called before the first frame update
    void Start()
    {
		is_contact = false;
		is_stay_area = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!is_contact)
        {
            GetComponent<SpriteRenderer>().color = new Color32(250, 207, 159, 255);
        }
    }

	
}
