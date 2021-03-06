﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AreaCircle : MonoBehaviour
{
	private GameObject _Player = default;
	private GameObject _Dice = default;
	private Rigidbody2D _rigidbody2D = default;
	private DiceStatus _diceStatus = default;
	public int del_dice_num = 0;
	public int dice_element_val = 0;

	private bool is_played = default;

	//FSMを持つゲームオブジェクト
	private GameObject _BatleStateMachine = default;
	// 呼び出したいFSM名  
	[SerializeField]
	private string FSM_reference_name = default;
	// 変更したい変数名  
	[SerializeField]
	private string variavle_name = default;
	private PlayMakerFSM[] FSMs;


	// Start is called before the first frame update
	void Start()
    {
		_Player = transform.parent.gameObject;
		_Dice = _Player.transform.Find("dice").gameObject;
		_rigidbody2D = _Player.GetComponent<Rigidbody2D>();
		_diceStatus = _Dice.GetComponent<DiceStatus>();
		is_played = false;

		_BatleStateMachine = GameObject.FindGameObjectWithTag("BattleStateMachine");
		FSMs = _BatleStateMachine.GetComponents<PlayMakerFSM>();
	}

    // Update is called once per frame
    void Update()
    {
		
    }

	//自身の動きが止まった時範囲内にあるかつ自身の面と同じ面のフィールドダイスを削除
	private void OnTriggerStay2D(Collider2D other_dice)
	{
		if(_rigidbody2D.velocity.normalized.magnitude == 0 && other_dice.CompareTag("other_dice"))
		{
			var other_dice_val = other_dice.GetComponent<DiceStatus>().GetElementVal();
			if (!is_played && other_dice_val == _diceStatus.GetElementVal())
			{
				dice_element_val = _diceStatus.GetElementVal();
				PlayEffectOtherDice();
				SetVariable();
				is_played = true;
			}
		}
	}

	//範囲内にフィールドダイスが入ったとき判定
	private void OnTriggerEnter2D(Collider2D other_dice)
	{
		//フィールドダイスの範囲内フラグをtrueに
		if(other_dice.CompareTag("other_dice"))
		{
			other_dice.GetComponent<ContactDice>().is_stay_area = true;
		}
	}

	//範囲内からフィールドダイスが出たとき判定
	private void OnTriggerExit2D(Collider2D other_dice)
	{
		//フィールドダイスの範囲内フラグをfalseに
		if (other_dice.CompareTag("other_dice"))
		{
			other_dice.GetComponent<ContactDice>().is_stay_area = false;
		}
	}

	//接触したことのあるフィールドダイスのエフェクトを表示
	private void PlayEffectOtherDice()
	{
		var clones = GameObject.FindGameObjectsWithTag("other_dice");
		foreach (var clone in clones)
		{
			var contact_dice = clone.GetComponent<ContactDice>();
			var play_effect = clone.GetComponent<PlayOtherDiceEffect>();
			var other_dice_val = clone.GetComponent<DiceStatus>().GetElementVal();
			if (contact_dice.is_contact && contact_dice.is_stay_area)
			{
				play_effect.PlayLightBall();
				del_dice_num += 1;
			}
			else if (contact_dice.is_stay_area && other_dice_val == _diceStatus.GetElementVal())
			{
				play_effect.PlayLightBall();
				del_dice_num += 1;
			}
		}
	}


	//ステート遷移用フラグをtrue
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
