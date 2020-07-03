using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMoveDice : MonoBehaviour
{

    //FSMを持つゲームオブジェクト
    public GameObject batle_state_machine;
    // 呼び出したいFSM名  
    public string FSM_reference_name;
    // 変更したい変数名  
    public string variavle_name;
    private PlayMakerFSM[] FSMs;

    private GameObject _player_dice = default;

    // Start is called before the first frame update
    void Start()
    {
        FSMs = batle_state_machine.GetComponents<PlayMakerFSM>();
    }

    private void OnEnable()
    {
        _player_dice = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_player_dice.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            SetVariable();
        }
    }

    public void SetVariable()
    {
        foreach (PlayMakerFSM fsm in FSMs)
        {
            if (fsm.FsmName == FSM_reference_name)
            {
                // 変数のSet  
                fsm.FsmVariables.GetFsmBool(variavle_name).Value = true;
            }
        }
    }
}
