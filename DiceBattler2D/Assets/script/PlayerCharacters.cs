using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacters : MonoBehaviour
{
    
    private const int all_chara_num = 3;
    [SerializeField]
    private GameObject[] m_CharacterPrefabs = new GameObject[all_chara_num];
    [SerializeField]
    private Sprite[] m_CharacterImages = new Sprite[all_chara_num];

    // Start is called before the first frame update
    void Start()
    {
        
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
        return m_CharacterImages[chara_num];
    }
}
