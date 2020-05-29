using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePow : MonoBehaviour
{
	[SerializeField]
	private GameObject player_dice = default;

	private ThrowDice _throw_dice = default;
	private Slider _slider = default;

    // Start is called before the first frame update
    void Start()
    {
		_throw_dice = player_dice.GetComponent<ThrowDice>();
		_slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
		//投擲パワー値をスライダーに表示するための処理
		_slider.maxValue = _throw_dice.max_pow;
		_slider.minValue = _throw_dice.min_pow;
		_slider.value = _throw_dice.throw_pow;
    }
}
