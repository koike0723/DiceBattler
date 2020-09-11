using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePlayerHP : MonoBehaviour
{

	private GameObject _PlayerCharacterContainer = default;
	private PlayerCharacters _playerCharacters = default;

	private GameObject _PartyMemberList = default;
	private PartyMembers _partyMembers = default;

	private int party_hp_max = default;
	private int party_hp = default;

	private Slider _slider = default;

	// Start is called before the first frame update
	void Start()
    {
		//GameObjectの取得
		_PlayerCharacterContainer = GameObject.FindGameObjectWithTag("PlayerCharaContainer");
		_PartyMemberList = GameObject.FindGameObjectWithTag("PartyMemberList");
		//Componentの取得
		_playerCharacters = _PlayerCharacterContainer.GetComponent<PlayerCharacters>();
		_partyMembers = _PartyMemberList.GetComponent<PartyMembers>();
		_slider = GetComponent<Slider>();

		party_hp_max = 0;
		for(int a = 0; a < _partyMembers.GetPartyLength(); a++)
		{
			party_hp_max += _playerCharacters.GetCharacterStatus(_partyMembers.GetPartyMember(a)).hp_max;
		}
		party_hp = party_hp_max;
		
    }

    // Update is called once per frame
    void Update()
    {
		_slider.maxValue = party_hp_max;
		_slider.value = party_hp;
    }

	public void DamagePlayerChara(int damage)
	{
		party_hp -= damage;
	}

	public int GetHP()
	{
		return party_hp;
	}
}
