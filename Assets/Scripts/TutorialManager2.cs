using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager2 : MonoBehaviour
{
    [SerializeField] GameObject goStageUI = null;

    public void BtnPlay()
    {
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

