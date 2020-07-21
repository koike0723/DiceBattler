using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStateDice : MonoBehaviour
{
    private bool is_penetrat = default;

    // Start is called before the first frame update
    void Start()
    {
        is_penetrat = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPenetration()
    {
        var other_dice = GameObject.FindGameObjectsWithTag("other_dice");
        foreach(var dice in other_dice)
        {
            dice.GetComponent<Collider2D>().isTrigger = true;
        }
        is_penetrat = true;
    }

    public void DelPenetration()
    {
        var other_dice = GameObject.FindGameObjectsWithTag("other_dice");
        foreach (var dice in other_dice)
        {
            dice.GetComponent<Collider2D>().isTrigger = false;
        }
        is_penetrat = false;
    }

}
