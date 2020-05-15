using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowVec : MonoBehaviour
{
	[SerializeField] GameObject player_dice;
	ThrowDice _throwDice;

    // Start is called before the first frame update
    void Start()
    {
		_throwDice = player_dice.GetComponent<ThrowDice>();
    }

    // Update is called once per frame
    void Update()
    {
		transform.rotation = Quaternion.FromToRotation(Vector3.up,_throwDice.swipeVec);
	}
}
