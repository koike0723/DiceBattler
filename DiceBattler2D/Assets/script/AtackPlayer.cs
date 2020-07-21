using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPlayer : MonoBehaviour
{
	private GameObject _Enemy = default;
	[SerializeField]
	private GameObject _DamageEffectParticle = default;
	private EnemyStatus _enemyStatus = default;

	private Rigidbody2D _rigidbody2D = default;

	private AreaCircle _areaCircle = default;
	private DiceStatus _diceStatus = default;

	// Start is called before the first frame update
	void Start()
	{
		_Enemy = GameObject.FindGameObjectWithTag("Enemy");

		_enemyStatus = _Enemy.GetComponent<EnemyStatus>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_areaCircle = transform.Find("area_circle").gameObject.GetComponent<AreaCircle>();
		_diceStatus = GetComponent<DiceStatus>();

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void AtackPlayerToEnemy()
	{
		int dmg = CalcDamage();
		_enemyStatus.Damage(dmg);
		Instantiate(_DamageEffectParticle, _Enemy.transform.position, Quaternion.identity);
	}

	public int CalcDamage()
	{
		
		return (_areaCircle.del_dice_num * _diceStatus.atk * 10) + (_diceStatus.atk * _areaCircle.dice_element_val);
	}
}
