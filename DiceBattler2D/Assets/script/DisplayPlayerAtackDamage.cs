using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerAtackDamage : MonoBehaviour
{
    [SerializeField]
    private GameObject _ValText = default;
    private Text _text = default;

    private GameObject _PlayerDice = default;
    private AtackPlayer _atackPlayer = default;

    // Start is called before the first frame update
    void Start()
    {
        _text = _ValText.GetComponent<Text>();
    }

    private void OnEnable()
    {
        _PlayerDice = GameObject.FindGameObjectWithTag("Player");
        _atackPlayer = _PlayerDice.GetComponent<AtackPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _atackPlayer.CalcDamage().ToString();

    }
}
