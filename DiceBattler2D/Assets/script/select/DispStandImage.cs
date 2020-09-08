using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispStandImage : MonoBehaviour
{

    private GameObject _PlayerCharactorContainer = default;
    private PlayerCharacters _playerCharacters = default;

    private SpriteRenderer _spriteRenderer = default;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerCharactorContainer = GameObject.FindGameObjectWithTag("PlayerCharaContainer");
        _playerCharacters = _PlayerCharactorContainer.GetComponent<PlayerCharacters>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStandImage(int char_ID)
    {
        _spriteRenderer.sprite = _playerCharacters.GetStandImage(char_ID);
    }
}
