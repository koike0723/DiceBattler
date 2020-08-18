using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControll : MonoBehaviour
{

    // 変数
    int frameCount;
    float prevTime;
    float fps;


    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        DispFPSLog();
    }

    private void DispFPSLog()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            Debug.Log(fps);

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}
