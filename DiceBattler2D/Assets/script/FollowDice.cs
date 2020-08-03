using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDice : MonoBehaviour
{

    private GameObject _PlayerDice = default;
    private Transform _playerDiceTransform = default;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerDice = GameObject.FindGameObjectWithTag("PlayerDice");
        _playerDiceTransform = _PlayerDice.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _playerDiceTransform.position;
    }
}
