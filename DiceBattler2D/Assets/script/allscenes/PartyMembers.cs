using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMembers : MonoBehaviour
{

    private const int member_num = 3;

    [System.NonSerialized]
    public int[] party_member = new int[member_num];

    // Start is called before the first frame update
    void Awake()
    {
        //for(int i = 0; i < member_num; i++)
        // {
        //     party_member[i] = i;
        // }
        party_member[0] = 1;
        party_member[1] = 2;
        party_member[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetPartyMember(int num)
    {
        return party_member[num];
    }

    public int GetPartyLength()
    {
        return party_member.Length;
    }
}
