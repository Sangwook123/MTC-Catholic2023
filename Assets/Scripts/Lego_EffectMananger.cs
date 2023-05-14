using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lego_EffectMananger : MonoBehaviour
{
    [SerializeField] Animator judgemantAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage = null;
    [SerializeField] Sprite[] judgementSprite = null;
    string hit = "Hit";
    Lego_MusicStart theMusicStart;

    public int[] judgementRecord = new int[5];

    void Start()
    {
        theMusicStart = FindObjectOfType<Lego_MusicStart>();
    }

    public void Initialized()
    {
        judgementRecord[0] = 0;
        judgementRecord[1] = 0;
        judgementRecord[2] = 0;
        judgementRecord[3] = 0;
        judgementRecord[4] = 0;
    }
    public void JudgementEffect(int p_num)
    {
        judgementImage.sprite = judgementSprite[p_num];
        judgemantAnimator.SetTrigger(hit);
        if (!theMusicStart.musicStop)
        {
            judgementRecord[p_num]++;
        }
    }

    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }

}