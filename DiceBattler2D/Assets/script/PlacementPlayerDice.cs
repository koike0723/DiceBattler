using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementPlayerDice : MonoBehaviour
{
    private GameObject _PlayerCharacterContainer = default;
    private PlayerCharacters _playerCharacters = default;

    private GameObject _PartyMemberList = default;
    private PartyMembers _partyMembers = default;


    private void Awake()
    {
        //GameObjectの取得
        _PlayerCharacterContainer = GameObject.FindGameObjectWithTag("PlayerCharaContainer");
        _PartyMemberList = GameObject.FindGameObjectWithTag("PartyMemberList");
        //Componentの取得
        _playerCharacters = _PlayerCharacterContainer.GetComponent<PlayerCharacters>();
        _partyMembers = _PartyMemberList.GetComponent<PartyMembers>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Placement(int mem_num)
    {
        var player_dice = GameObject.FindGameObjectWithTag("Player");
        if(player_dice != null)
        {
            GameObject.Destroy(player_dice);
        }
        GameObject.Instantiate(_playerCharacters.GetCharacterPrefab(_partyMembers.party_member[mem_num]));
    }
}
