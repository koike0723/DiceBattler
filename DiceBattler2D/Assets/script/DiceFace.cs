using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceFace: MonoBehaviour
{
	public static int face_num = 6;
	SpriteRenderer _spriterender;
	//サイコロの面画像収納
	[SerializeField] Sprite[] m_sprite = new Sprite[face_num];
	//サイコロの面値収納
	[SerializeField] int[] m_element_val = new int[face_num];
	
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
		_spriterender.sprite = m_sprite[element_num];
	}

	//サイコロの面値の取得処理
	public int GetElementVal(int element_num)
	{
		return m_element_val[element_num];
	}
}
