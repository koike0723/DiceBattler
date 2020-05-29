using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageEnemyHP : MonoBehaviour
{
	[SerializeField]
	private GameObject enemy = default;

	private EnemyStatus _enemy_status = default;
	private Slider _slider = default;

	// Start is called before the first frame update
	void Start()
	{
		_enemy_status = enemy.GetComponent<EnemyStatus>();
		_slider = GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update()
	{
		_slider.maxValue = _enemy_status.hp_max;
		_slider.value = _enemy_status.GetDiceHP();
	}
}
