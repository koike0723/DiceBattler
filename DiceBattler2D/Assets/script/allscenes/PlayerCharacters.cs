using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacters : MonoBehaviour
{

    private const int all_chara_num = 5;

    [SerializeField]
    private GameObject[] m_CharacterPrefabs = new GameObject[all_chara_num];
    [SerializeField]
    private Sprite[] m_characterImages = new Sprite[all_chara_num];
    [SerializeField]
    private Sprite[] m_standImages = new Sprite[all_chara_num];
    private DiceStatus[] m_diceStatuses = new DiceStatus[all_chara_num];

    // Start is called before the first frame update
    void Awake()
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

    //キャラクタープレハブの取得
    public GameObject GetCharacterPrefab(int chara_num)
    {
        return m_CharacterPrefabs[chara_num];
    }

    //キャラクターの顔画像の取得
    public Sprite GetCharacterImage(int chara_num)
    {
        return m_characterImages[chara_num];
    }

    //キャラクターの立ち絵の取得
    public Sprite GetStandImage(int chara_num)
    {
        return m_standImages[chara_num];
    }

    //キャラクターの性能を取得
    public DiceStatus GetCharacterStatus(int chara_num)
    {
        return m_diceStatuses[chara_num];
    }
}
