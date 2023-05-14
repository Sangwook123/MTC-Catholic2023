using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBTN : MonoBehaviour
{
    [SerializeField] GameObject goMainStart = null;
    [SerializeField] GameObject goStageUI = null;
    [SerializeField] GameObject Funvi = null;
    [SerializeField] GameObject ConVi = null;
    [SerializeField] GameObject HealVi = null;

    public void BtnMainStart(){
        goStageUI.SetActive(true);
        Funvi.SetActive(false);
        ConVi.SetActive(false);
        HealVi.SetActive(false);
        goMainStart.SetActive(false);
    }
}
