using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRandomize: MonoBehaviour
{
	DiceFace _diceface = default;

    // Start is called before the first frame update
    void Start()
    {
		_diceface = GetComponent<DiceFace>();
		_diceface.SetSprite(Random.Range(0, DiceFace.face_num * 100) % DiceFace.face_num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
