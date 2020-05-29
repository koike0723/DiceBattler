﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePowGauge : MonoBehaviour
{
	[SerializeField]
	GameObject player_dice = default;

	ThrowDice _throwDice;
	Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
		_throwDice = player_dice.GetComponent<ThrowDice>();
		_slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
		//投擲パワー値をスライダーに表示するための処理
		_slider.maxValue = _throwDice.max_pow;
		_slider.minValue = _throwDice.min_pow;
		_slider.value = _throwDice.throw_pow;
    }
}
