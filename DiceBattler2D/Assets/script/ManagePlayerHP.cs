using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePlayerHP : MonoBehaviour
{
	[SerializeField]
	private GameObject player_dice = default;

	private DiceStatus _dice_status= default;
	private Slider _slider = default;

	// Start is called before the first frame update
	void Start()
    {
		_dice_status = player_dice.GetComponent<DiceStatus>();
		_slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
		_slider.maxValue = _dice_status.hp_max;
		_slider.value = _dice_status.GetDiceHP();
    }
}
