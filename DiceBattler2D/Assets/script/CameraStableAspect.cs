using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode()]
[RequireComponent(typeof(Camera))]
public class CameraStableAspect : MonoBehaviour
{

	[SerializeField]
	private Camera ref_camera;
	[SerializeField]
	private int width = 1080;
	[SerializeField]
	private int height = 1920;
	[SerializeField]
	private float pixel_per_unit = 100f;

	private int m_width = -1;
	private int m_height = -1;

	private void Awake()
	{
		if(ref_camera == null)
		{
			ref_camera = GetComponent<Camera>();
		}
		UpdateCamera();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		UpdateCameraWithCheck();
    }

	void UpdateCameraWithCheck()
	{
		if(m_width == Screen.width && m_height == Screen.height)
		{
			return;
		}
		UpdateCamera();
	}

	void UpdateCamera()
	{
		float screen_w = (float)Screen.width;
		float screen_h = (float)Screen.height;
		float target_w = (float)width;
		float target_h = (float)height;

		float aspect = screen_w / screen_h;
		float target_aspect = target_w / target_h;
		float orhtographic_size = (target_h / 2f / pixel_per_unit);

		if(aspect < target_aspect)
		{
			float bg_scale_w = target_w / screen_w;
			float cam_height = target_h / (screen_h * bg_scale_w);
			ref_camera.rect = new Rect(0f, (1f - cam_height) * 0.5f, 1f, cam_height);
		}
		else
		{
			float bg_scale = aspect / target_aspect;
			orhtographic_size *= bg_scale;

			float bg_scale_h = target_h / screen_h;
			float cam_width = target_w / (screen_w * bg_scale);
			ref_camera.rect = new Rect((1f-cam_width)*0.5f, 0f, cam_width, 1f);
		}

		ref_camera.orthographicSize = orhtographic_size;

		m_width = Screen.width;
		m_height = Screen.height;
	}
}
