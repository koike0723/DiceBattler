using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePowGauge : MonoBehaviour
{
	private GameObject _PlayerDice = default;

	private ThrowDice _throwDice = default;
	private Slider _slider = default;

    // Start is called before the first frame update
    void Start()
    {
		_PlayerDice = GameObject.FindGameObjectWithTag("Player");
		_throwDice = _PlayerDice.GetComponent<ThrowDice>();
		_slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
		//投擲パワー値をスライダーに表示するための処理
		_slider.maxValue = _throwDice.maxPow;
		_slider.minValue = _throwDice.minPow;
		_slider.value = _throwDice.thorowPow;
    }
}
