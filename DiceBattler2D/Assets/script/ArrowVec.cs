using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowVec : MonoBehaviour
{
	private GameObject _PlayerDice = default;
	private ThrowDice _throwDice = default;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //playerdiceが生成後にcomponent取得を行いたいためstartで処理
        _PlayerDice = GameObject.FindGameObjectWithTag("PlayerDice");
        _throwDice = _PlayerDice.transform.GetComponent<ThrowDice>();
    }

    // Update is called once per frame
    void Update()
    {
		transform.rotation = Quaternion.FromToRotation(Vector3.up,_throwDice.swipeVec);
	}

    public void ResetPlayerDice()
    {
        _PlayerDice = GameObject.FindGameObjectWithTag("PlayerDice");
        _throwDice = _PlayerDice.GetComponent<ThrowDice>();
    }
}
