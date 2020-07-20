using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOtherDiceEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _ParticleLightBall = default;
    private StopedEffect _stopedEffect = default;
    private GameObject _InstantParticle = default;

    private bool is_play_effect = default;

    private void Awake()
    {
        is_play_effect = false;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(is_play_effect)
        {
            if (_stopedEffect.is_stop)
            {
                Destroy(this.gameObject);
                Destroy(_InstantParticle);
                is_play_effect = false;
            }
        }
    }

    public void PlayEffect()
    {
        var parent = this.transform;
        _InstantParticle = Instantiate(_ParticleLightBall, parent.position, Quaternion.identity);
        _stopedEffect = _InstantParticle.GetComponent<StopedEffect>();
        is_play_effect = true;
    }

}
