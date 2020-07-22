using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackEnemy : MonoBehaviour
{
    private GameObject _PartyHP = default;
    private ManagePlayerHP _managePlayerHP= default;

    [SerializeField]
    private GameObject _DamageEffectParticle = default;

    // Start is called before the first frame update
    void Start()
    {
        _PartyHP = GameObject.FindGameObjectWithTag("PartyHP");
        _managePlayerHP = _PartyHP.GetComponent<ManagePlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtackEnemyToPlayer()
    {
        int dmg = CalcDamage();
        _managePlayerHP.DamagePlayerChara(dmg);
        Instantiate(_DamageEffectParticle);
    }

    public int CalcDamage()
    {

        return 10;
    }
}
