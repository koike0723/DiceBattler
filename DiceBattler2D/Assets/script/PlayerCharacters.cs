using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacters : MonoBehaviour
{
    
    private const int all_chara_num = 3;
    [SerializeField]
    private GameObject[] m_CharacterPrefabs = new GameObject[all_chara_num];
    [SerializeField]
    private Sprite[] m_characterImages = new Sprite[all_chara_num];
    private DiceStatus[] m_diceStatuses = new DiceStatus[all_chara_num];

    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        foreach (var prefab in m_CharacterPrefabs)
        {
            m_diceStatuses[count++] = prefab.transform.Find("dice").GetComponent<DiceStatus>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetCharacterPrefab(int chara_num)
    {
        return m_CharacterPrefabs[chara_num];
    }

    public Sprite GetCharacterImage(int chara_num)
    {
        return m_characterImages[chara_num];
    }
    public DiceStatus GetCharacterStatus(int chara_num)
    {
        return m_diceStatuses[chara_num];
    }
}
