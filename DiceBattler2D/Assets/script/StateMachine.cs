using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//状態定義
public enum StateType
{
	Idle,
	Run,
	Jump,
}

//一つ一つの状態をstateパターンで実装するためのクラス
public abstract class State
{
	public abstract void Enter();
	public abstract void Update();
}

public class IdleState : State
{
	public override void Enter()
	{
		Debug.Log("Enter:Idle");
	}
	public override void Update()
	{
		
	}
}

public class RunState : State
{
	public override void Enter()
	{
		Debug.Log("Enter:Run");
	}
	public override void Update()
	{

	}
}

public class JumpState : State
{
	public override void Enter()
	{
		Debug.Log("Enter:Jump");	
	}
	public override void Update()
	{

	}
}

public class Transition
{
	public StateType To { get; set; }
	public KeyCode Trigger { get; set; }
}

public class StateMachine : MonoBehaviour
{
	//現在のステートタイプ
	private StateType _state_type;
	//現在のステート
	private State _state;

	public bool is_trigger = default;
	public KeyCode key = default;


	//stateのインスタンスのキャッシュ
	private Dictionary<StateType, State> _state_types = new Dictionary<StateType, State>();
	//遷移情報
	private Dictionary<StateType, List<Transition>> _transition_lists = new Dictionary<StateType, List<Transition>>();

	private void Awake()
	{
		//stateのインスタンスを登録しておく
		_state_types.Add(StateType.Idle, new IdleState());
		_state_types.Add(StateType.Run, new RunState());
		_state_types.Add(StateType.Jump, new JumpState());

		//遷移を登録する
		AddTransition(StateType.Idle, StateType.Run, KeyCode.R);
		AddTransition(StateType.Idle, StateType.Jump, KeyCode.J);
		AddTransition(StateType.Run, StateType.Idle, KeyCode.I);
		AddTransition(StateType.Jump, StateType.Idle, KeyCode.I);
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		var transitions = _transition_lists[_state_type];
		foreach (var transition in transitions)
		{
			if (TransitionState(transition.Trigger))
			{
				//登録されたトリガーが呼ばれたら遷移
				_state_type = transition.To;
				_state = _state_types[_state_type];
				_state.Enter();
				_state.Update();
				break;
			}
		}
	}

	private bool TransitionState(KeyCode keycode)
	{
		if(is_trigger)
		{
			if(key == keycode)
			{
				return true;
			}
		}

		return false;
	}

	///<summary>
	///遷移情報を登録する
	///</summary>
	///<param name="from">遷移元のStateType</param>
	///<param name="to">遷移先のStateType</praam>
	///<param name="trigger">トリガーとなるキー</param>
	private void AddTransition(StateType from, StateType to, KeyCode trigger)
	{
		if (!_transition_lists.ContainsKey(from))
		{
			_transition_lists.Add(from, new List<Transition>());
		}
		var transitions = _transition_lists[from];
		var transition = transitions.FirstOrDefault(x => x.To == to);
		if (transition == null)
		{
			//新規登録
			transitions.Add(new Transition { To = to, Trigger = trigger });
		}
		else
		{
			//更新
			transition.To = to;
			transition.Trigger = trigger;
		}
	}
}
