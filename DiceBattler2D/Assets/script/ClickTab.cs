using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTab : MonoBehaviour
{
	[SerializeField]
	private GameObject _open_tab = default;
	[SerializeField]
	private GameObject _close_tab = default;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnClickOpen()
	{
		_open_tab.SetActive(true);
		_close_tab.SetActive(false);
	}

	public void OnClickClose()
	{
		_open_tab.SetActive(false);
		_close_tab.SetActive(true);
	}
}
