using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEnemyAtackDamage : MonoBehaviour
{
    [SerializeField]
    private GameObject _ValText = default;
    private Text _text = default;

    private GameObject _Enemy = default;
    private AtackEnemy _atackEnemy = default;


    // Start is called before the first frame update
    void Start()
    {
        _text = _ValText.GetComponent<Text>();
    }

    private void OnEnable()
    {
        _Enemy = GameObject.FindGameObjectWithTag("Enemy");
        _atackEnemy = _Enemy.GetComponent<AtackEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _atackEnemy.CalcDamage().ToString();
    }
}
