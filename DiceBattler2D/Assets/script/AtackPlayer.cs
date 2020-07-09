using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPlayer : MonoBehaviour
{
	private GameObject _Enemy = default;
	private EnemyStatus _enemyStatus = default;

	private Rigidbody2D _rigidbody2D = default;
	private ThrowDice _throwDice = default;
	private bool is_damage = default;

	private AreaCircle _area_circle = default;
	private DiceStatus _dice_status = default;

    // Start is called before the first frame update
    void Start()
    {
		_Enemy = GameObject.FindGameObjectWithTag("Enemy");

		_enemyStatus = _Enemy.GetComponent<EnemyStatus>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_throwDice = GetComponent<ThrowDice>();
		_area_circle = transform.Find("area_circle").gameObject.GetComponent<AreaCircle>();
		_dice_status = GetComponent<DiceStatus>();

		is_damage = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (_area_circle.is_action && !is_damage)
		{
			int dmg = (_area_circle.del_dice_num * _dice_status.atk * 10) + (_dice_status.atk * _area_circle.dice_element_val);
			_enemyStatus.Damage(dmg);
			is_damage = true;
		}
    }
}
