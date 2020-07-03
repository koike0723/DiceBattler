using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VariavleName
{
    isThrow,
    isCancel,
}

public class CheckThrowingDice : MonoBehaviour
{
   
    //FSMを持つゲームオブジェクト
    public GameObject batle_state_machine;
    // 呼び出したいFSM名  
    public string FSM_reference_name;
    // 変更したい変数名  
    public string[] variavle_name;
    private PlayMakerFSM[] FSMs;

    // Start is called before the first frame update
    void Start()
    {
        FSMs = batle_state_machine.GetComponents<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVariable(VariavleName name)
    {
        int num = -1;
        switch(name)
        {
            case VariavleName.isThrow:
                num = 0;
                break;
            case VariavleName.isCancel:
                num = 1;
                break;
            default:
                num = -1;
                break;
        }

        if(num < 0)
        {
            Debug.Log("不正な数値が入力");
            return;
        }

        foreach (PlayMakerFSM fsm in FSMs)
        {
            if (fsm.FsmName == FSM_reference_name)
            {
                // 変数のSet  
                fsm.FsmVariables.GetFsmBool(variavle_name[num]).Value = true;
            }
        }
    }
}
