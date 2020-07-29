using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStopOtherDIce : MonoBehaviour
{
    private bool[] is_sleep_dices;
    //FSMを持つゲームオブジェクト
    private GameObject _BattleStateMachine;
    // 呼び出したいFSM名  
    private string FSM_reference_name;
    // 変更したい変数名  
    [SerializeField, Header("FSM用flg変数")]
    private string variavle_name;
    private PlayMakerFSM[] FSMs;


    // Start is called before the first frame update
    void Start()
    {
        _BattleStateMachine = GameObject.FindGameObjectWithTag("BattleStateMachine");
        FSMs = _BattleStateMachine.GetComponents<PlayMakerFSM>();
        FSM_reference_name = "TurnStateController";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        var clones = GameObject.FindGameObjectsWithTag("other_dice");
        is_sleep_dices = new bool[clones.Length];
        int clone_num = 0;
        foreach (var clone in clones)
        {
            if (clone.GetComponent<Rigidbody2D>().IsSleeping())
            {
                is_sleep_dices[clone_num] = true;
            }
            clone_num++;
        }

        if (IsSleepAllDice())
        {
            SetVariable();
        }
    }

    void SetVariable()
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

    bool IsSleepAllDice()
    {
        if(is_sleep_dices == null)
        {
            return false;
        }

        foreach (var is_sleep in is_sleep_dices)
        {
            if (!is_sleep)
            {
                return false;
            }
        }
        return true;
    }
}
