using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPlayer : MonoBehaviour
{
	private GameObject _Enemy = default;
	[SerializeField]
	private GameObject _DamageEffectParticle = default;
	private EnemyStatus _enemyStatus = default;

	private AreaCircle _areaCircle = default;
	private DiceStatus _diceStatus = default;

	// Start is called before the first frame update
	void Start()
	{
		_Enemy = GameObject.FindGameObjectWithTag("Enemy");

		_enemyStatus = _Enemy.GetComponent<EnemyStatus>();
		_areaCircle = transform.Find("area_circle").gameObject.GetComponent<AreaCircle>();
		_diceStatus = transform.Find("dice").GetComponent<DiceStatus>();

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void AtackPlayerToEnemy()
	{
		int dmg = CalcDamage();
		_enemyStatus.DamageEnemy(dmg);
		Instantiate(_DamageEffectParticle, _Enemy.transform.position, Quaternion.identity);
	}

	public int CalcDamage()
	{
		
		return (_areaCircle.del_dice_num * _diceStatus.atk * 10) + (_diceStatus.atk * _areaCircle.dice_element_val);
	}
}
