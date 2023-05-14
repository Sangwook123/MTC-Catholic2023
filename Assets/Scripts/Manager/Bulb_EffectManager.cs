using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb_EffectManager : MonoBehaviour
{
    string hit = "Hit";
    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage = null;
    [SerializeField] Sprite[] judgementSprite = null;

    public int[] judgementRecord = new int[5];

    Bulb_MusicStart theMusicStart;

    public bool isMiss = false;

    public AudioSource beebSound;

    void Start()
    {
        theMusicStart = FindObjectOfType<Bulb_MusicStart>();
        beebSound = FindObjectOfType<AudioSource>();
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
        judgementAnimator.SetTrigger(hit);

        if (p_num == 4)
        {
            isMiss = true;
            beebSound.Play();
        }
        else
        {
            isMiss = false;
        }

        if(!theMusicStart.musicStop)
        {
            judgementRecord[p_num]++;
        }
        
    }

    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }

    public bool CheckMiss()
    {
        return isMiss;
    }

    
}
