using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel_EffectManager : MonoBehaviour
{
    string hit = "Hit";

    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage = null;
    [SerializeField] Sprite[] judgementSprite = null;

    public void JudgementEffect(int p_num) 
    {
        //����Ʈ �ȿ� �ִ� perfect, cool, good �� �̹��� ���
        judgementImage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }
}
