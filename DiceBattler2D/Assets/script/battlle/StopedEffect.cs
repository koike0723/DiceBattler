using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopedEffect : MonoBehaviour
{

    public bool is_stop = default;

    // Start is called before the first frame update
    void Start()
    {
        is_stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleSystemStopped()
    {
        is_stop = true;
    }
}
