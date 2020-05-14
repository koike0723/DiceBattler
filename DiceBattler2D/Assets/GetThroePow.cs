using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetThroePow : MonoBehaviour
{
	ThrowDice _throwDice;
	Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
		_throwDice = GameObject.Find("dice").GetComponent<ThrowDice>();
		_slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
		_slider.maxValue = _throwDice.max_pow;
		_slider.minValue = _throwDice.min_pow;
		_slider.value = _throwDice.throw_pow;
    }
}
