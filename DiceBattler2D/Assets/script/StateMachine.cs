using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状態定義
public enum StateType
{
	Idle,
	Run,
}

//一つ一つの状態をstateパターンで実装するためのクラス
public abstract class State
{
	public abstract void Enter();
}

public class IdleState : State
{
	public override void Enter()
	{
		Debug.Log("Enter:Idle");
	}
}

public class RunState : State
{
	public override void Enter()
	{
		Debug.Log("Enter:Run");
	}
}

public class StateMachine : MonoBehaviour
{
	//現在のステートタイプ
	private StateType _state_type;
	//現在のステート
	private State _state;

	//stateのインスタンスのキャッシュ
	private Dictionary<StateType, State> _states = new Dictionary<StateType, State>();


	private void Awake()
	{
		//stateのインスタンスを登録しておく
		_states.Add(StateType.Idle, new IdleState());
		_states.Add(StateType.Run, new RunState());
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(_state_type)
		{
			case StateType.Idle:
				if(Input.GetKeyDown(KeyCode.R))
				{
					//stateTypeとstateを切り替え
					_state_type = StateType.Run;
					_state = _states[_state_type];
					//Enterを呼ぶ
					_state.Enter();
				}
				break;
			case StateType.Run:
				if(Input.GetKeyDown(KeyCode.I))
				{
					//StateTypeとstateを切り替え
					_state_type = StateType.Idle;
					_state = _states[_state_type];
					//Enterを呼ぶ
					_state.Enter();
				}
				break;
		}
    }
}
