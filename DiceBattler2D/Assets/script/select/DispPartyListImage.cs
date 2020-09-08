using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispPartyListImage : MonoBehaviour
{

    private const int party_mem_num = 3;

    [SerializeField]
    private GameObject[] m_PartyListFrames = new GameObject[party_mem_num];

    private GameObject _PlayerCharactorContainer = default;
    private PlayerCharacters _playerCharacters = default;

    private GameObject _PartyList = default;
    private PartyMembers _partyMembers = default;

    // Start is called before the first frame update
    void Start()
    {
        _PartyList = GameObject.FindGameObjectWithTag("PartyMemberList");
        _partyMembers = _PartyList.GetComponent<PartyMembers>();

        _PlayerCharactorContainer = GameObject.FindGameObjectWithTag("PlayerCharaContainer");
        _playerCharacters = _PlayerCharactorContainer.GetComponent<PlayerCharacters>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < party_mem_num; i++)
        {
            var spriteRenderer = m_PartyListFrames[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _playerCharacters.GetCharacterImage(_partyMembers.GetPartyMember(i));
        }
    }
}
