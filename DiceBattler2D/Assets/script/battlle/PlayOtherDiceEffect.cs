using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOtherDiceEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _ParticleLightBall = default;
    private StopedEffect _stopedLightBall = default;
    private GameObject _InstantLightBall = default;
    private bool is_play_lightball = default;

    [SerializeField]
    private GameObject _ParticleHexShield = default;
    private StopedEffect _stopedHexShield = default;
    private GameObject _InstantHexShield = default;
    private bool is_play_hexshield = default;


    private void Awake()
    {
        is_play_lightball = false;
        is_play_hexshield = false;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(is_play_lightball)
        {
            if (_stopedLightBall.is_stop)
            {
                Destroy(this.gameObject);
                Destroy(_InstantLightBall);
                is_play_lightball = false;
            }
        }

        if(is_play_hexshield)
        {
            if(_stopedHexShield.is_stop)
            {
                Destroy(_InstantHexShield);
                is_play_hexshield = false;
            }
        }
    }

    public void PlayLightBall()
    {
        var parent = this.transform;
        _InstantLightBall = Instantiate(_ParticleLightBall, parent.position, Quaternion.identity);
        _stopedLightBall = _InstantLightBall.GetComponent<StopedEffect>();
        is_play_lightball = true;
    }

    public void PlayHexShield()
    {
        var parent = this.transform;
        _InstantHexShield = Instantiate(_ParticleHexShield, parent.position, Quaternion.identity);
        _stopedHexShield = _InstantHexShield.GetComponent<StopedEffect>();
        is_play_hexshield = true;
    }

}
