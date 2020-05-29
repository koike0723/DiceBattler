using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceStatus: MonoBehaviour
{
	public static int face_num = 6;
	SpriteRenderer _spriterender;
	//サイコロの面画像収納
	[SerializeField]
	private Sprite[] m_sprite = new Sprite[face_num];
	//サイコロの面値収納
	[SerializeField]
	private int[] m_element_val = new int[face_num];

	[SerializeField]
	private int dice_hp = 0;
	public int hp_max = 100;
	public int atk = 5;


	//表示している面の要素番号
	private int now_element_num = 0;

	private void Awake()
	{
		_spriterender = GetComponent<SpriteRenderer>();
	}

	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

	//サイコロの面画像の設定処理
	public void SetSprite(int element_num)
	{
		now_element_num = element_num;
		_spriterender.sprite = m_sprite[now_element_num];
	}

	//サイコロの面値の取得処理
	public int GetElementVal(int element_num)
	{
		return m_element_val[element_num];
	}
	public int GetElementVal()
	{
		return m_element_val[now_element_num];
	}

	public int GetDiceHP()
	{
		return dice_hp;
	}

	public void DamegeDice(int damage)
	{
		dice_hp -= damage;
	}
}
