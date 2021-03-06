﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackEnemy : MonoBehaviour
{
    private GameObject _PartyHP = default;
    private ManagePlayerHP _managePlayerHP= default;

    private GameObject _NoticeDice = default;
    private CountOtherDice _countOtherDice = default;

    private DiceStatus _noticeDiceStatus = default;
    private EnemyStatus _enemyStatus = default;

    [SerializeField]
    private GameObject _DamageEffectParticle = default;

    // Start is called before the first frame update
    void Start()
    {
        _PartyHP = GameObject.FindGameObjectWithTag("PartyHP");
        _managePlayerHP = _PartyHP.GetComponent<ManagePlayerHP>();

        _NoticeDice = GameObject.FindGameObjectWithTag("NoticeDice");
        _countOtherDice = _NoticeDice.GetComponent<CountOtherDice>();
        _noticeDiceStatus = _NoticeDice.GetComponent<DiceStatus>();

        _enemyStatus = this.GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtackEnemyToPlayer()
    {
        int dmg = CalcDamage();
        _managePlayerHP.DamagePlayerChara(dmg);
        Instantiate(_DamageEffectParticle);
    }

	public void AtackEnemyToPlayer(int dmg)
	{
		_managePlayerHP.DamagePlayerChara(dmg);
		Instantiate(_DamageEffectParticle);
	}

	public int CalcDamage()
    {

        return (_countOtherDice.other_dice_count * _enemyStatus.atk * 10) + (_enemyStatus.atk * _noticeDiceStatus.GetElementVal());
    }
}
