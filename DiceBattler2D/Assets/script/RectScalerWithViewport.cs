using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode()]

public class RectScalerWithViewport : MonoBehaviour
{
	[SerializeField]
	RectTransform ref_rect = null;

	[SerializeField]
	Vector2 reference_resolution = new Vector2(1920, 1080);

	[Range(0, 1)]
	[SerializeField]
	float match_width_or_height = 0;

	float m_width = -1;
	float m_height = -1;

	private const float k_log_base = 2;

	private void Awake()
	{
		if(ref_rect == null)
		{
			ref_rect = GetComponent<RectTransform>();
		}
		UpdateRect();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		UpdateRectEithCheck();
    }

	private void OnValidate()
	{
		UpdateRect();
	}

	void UpdateRectEithCheck()
	{
		Camera cam = Camera.main;
		float width = cam.rect.width * Screen.width;
		float height = cam.rect.height * Screen.height;
		if(m_width == width && m_height == height)
		{
			return;
		}
		UpdateRect();
	}

	void UpdateRect()
	{
		Camera cam = Camera.main;
		float width = cam.rect.width * Screen.width;
		float height = cam.rect.height * Screen.height;

		m_width = width;
		m_height = height;

		float log_width = Mathf.Log(width / reference_resolution.x, k_log_base);
		float log_height = Mathf.Log(height / reference_resolution.y, k_log_base);
		float log_weighted_average = Mathf.Lerp(log_width, log_height, match_width_or_height);
		float scale = Mathf.Pow(k_log_base, log_weighted_average);

		ref_rect.localScale = new Vector3(scale, scale, scale);

		float rev_scale = 1f / scale;
		ref_rect.sizeDelta = new Vector2(m_width * rev_scale, m_height * rev_scale);
	}
}
