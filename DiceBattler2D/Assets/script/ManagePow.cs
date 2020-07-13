using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePow : MonoBehaviour
{
	private GameObject _PlayerDice = default;

	private ThrowDice _throwDice = default;
	private Slider _slider = default;


	private void Awake()
	{
		
	}

	// Start is called before the first frame update
	void Start()
    {
		//playerdiceが生成後にcomponent取得を行いたいためstartで処理
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

	public void ResetPlayerDice()
	{
		_PlayerDice = GameObject.FindGameObjectWithTag("Player");
		_throwDice = _PlayerDice.GetComponent<ThrowDice>();
	}
}
