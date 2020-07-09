using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharaImage : MonoBehaviour
{
    private GameObject _PlayerCharacterContainer = default;
    private PlayerCharacters _playerCharacters = default;

    private GameObject _PartyMemberList = default;
    private PartyMembers _partyMembers = default;

    private SpriteRenderer _spriteRenderer = default;

    [SerializeField]
    private int mem_num = 0;

    private void Awake()
    {
        //GameObjectの取得
        _PlayerCharacterContainer = GameObject.FindGameObjectWithTag("PlayerCharaContainer");
        _PartyMemberList = GameObject.FindGameObjectWithTag("PartyMemberList");
        //Componentの取得
        _playerCharacters = _PlayerCharacterContainer.GetComponent<PlayerCharacters>();
        _partyMembers = _PartyMemberList.GetComponent<PartyMembers>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = _playerCharacters.GetCharacterImage(_partyMembers.party_member[mem_num]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
