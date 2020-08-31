using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchNoticeNum : MonoBehaviour
{

    [SerializeField]
    private GameObject _EffectNoticeDice = default;
    private NoticeDiceNum _noticeDiceNum = default;

    private DiceStatus _diceStatus = default;

    // Start is called before the first frame update
    void Start()
    {
        _noticeDiceNum = _EffectNoticeDice.GetComponent<NoticeDiceNum>();
        _diceStatus = this.GetComponent<DiceStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Match()
    {
        _diceStatus.SetSprite(_noticeDiceNum.face_element_num);
    }
}
