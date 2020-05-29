﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
	[SerializeField]
	private int enemy_hp = 0;
	public int hp_max = 100;

	public int enemy_atk = 10;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public int GetDiceHP()
	{
		return enemy_hp;
	}

	public void Damage(int damage)
	{
		enemy_hp -= damage;
	}
}