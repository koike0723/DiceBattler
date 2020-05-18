using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceFace: MonoBehaviour
{
	public static int face_num = 6;
	SpriteRenderer _spriterender;
	//サイコロの面画像収納
	[SerializeField]
	Sprite[] m_sprite = new Sprite[face_num];
	//サイコロの面値収納
	[SerializeField]
	int[] m_element_val = new int[face_num];

	//表示している面の要素番号
	private int now_element_num = 0; 

	// Start is called before the first frame update
	void Start()
    {
		_spriterender = GetComponent<SpriteRenderer>();
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
}
