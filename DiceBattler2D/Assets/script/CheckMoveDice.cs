using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMoveDice : MonoBehaviour
{

    //FSMを持つゲームオブジェクト
    private GameObject _BattleStateMachine = default;
    // 呼び出したいFSM名  
    [SerializeField]
    private string FSM_reference_name = default;
    // 変更したい変数名  
    [SerializeField]
    private string variavle_name = default;
    private PlayMakerFSM[] FSMs = default;

    private GameObject _PlayerDice = default;

    // Start is called before the first frame update
    void Start()
    {
        //gameobjectの取得をplayerdiceの生成後行いたいためstartで処理
        _BattleStateMachine = GameObject.FindGameObjectWithTag("BattleStateMachine");
        FSMs = _BattleStateMachine.GetComponents<PlayMakerFSM>();
    }

    private void OnEnable()
    {
        _PlayerDice = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_PlayerDice.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
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
