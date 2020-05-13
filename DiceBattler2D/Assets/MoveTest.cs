using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float x = Input.GetAxisRaw("Horizontal");
		x = x / 10.0f;
		float y = Input.GetAxisRaw("Vertical");
		y = y / 10.0f;
		this.transform.position += new Vector3(x, y);
	}
}
