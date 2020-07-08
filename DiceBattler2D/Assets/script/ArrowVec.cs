using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowVec : MonoBehaviour
{
	private GameObject _PlayerDice = default;
	private ThrowDice _throwDice;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerDice = GameObject.FindGameObjectWithTag("Player");
		_throwDice = _PlayerDice.GetComponent<ThrowDice>();
    }

    // Update is called once per frame
    void Update()
    {
		transform.rotation = Quaternion.FromToRotation(Vector3.up,_throwDice.swipeVec);
	}
}
