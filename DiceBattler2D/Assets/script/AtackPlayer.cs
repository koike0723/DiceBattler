using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPlayer : MonoBehaviour
{
	[SerializeField]
	private GameObject _enemy = default;
	private EnemyStatus _enemy_status = default;

	private Rigidbody2D _rigidbody2D = default;
	private ThrowDice _throw_dice = default;
	private bool is_damage = default;

	private AreaCircle _area_circle = default;
	private DiceStatus _dice_status = default;

    // Start is called before the first frame update
    void Start()
    {
		_enemy_status = _enemy.GetComponent<EnemyStatus>();

		_rigidbody2D = GetComponent<Rigidbody2D>();
		_throw_dice = GetComponent<ThrowDice>();
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
			_enemy_status.Damage(dmg);
			is_damage = true;
		}
    }
}
