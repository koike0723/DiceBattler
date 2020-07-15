using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFrameOfThrowedDice : MonoBehaviour
{

    private Collider2D _collider2D = default;
    private SpriteRenderer _spriteRenderer = default;
    private bool is_throwed = default;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(is_throwed)
        {
            _collider2D.enabled = false;
            _spriteRenderer.color = Color.gray;
        }
        else
        {
            _collider2D.enabled = true;
            _spriteRenderer.color = Color.white;
        }
    }

    public void SwitchIsThrowed(bool throwed)
    {
        is_throwed = throwed;
    }

    public bool GetIsThrowed()
    {
        return is_throwed;
    }
}
