using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunVillBtn : MonoBehaviour
{
    [SerializeField] GameObject goBaseball = null;
    [SerializeField] GameObject goLego = null;

    FunOnOff funonoff;


    public int LegoisClear;
    public int BaseballisClear;


    void Start()
    {
        
        /*PlayerPrefs.SetInt("legoisclear", 0);
        PlayerPrefs.SetInt("baseballisclear", 0);*/
        
        LegoisClear = 0;
        BaseballisClear = 0;
        funonoff = FindObjectOfType<FunOnOff>();
    }

    void Update()
    {
        LegoisClear = PlayerPrefs.GetInt("legoisclear");
        BaseballisClear = PlayerPrefs.GetInt("baseballisclear");

        if(LegoisClear == 1 && BaseballisClear == 0)
        {
            funonoff.Fun_Lego_On();
        }
        else if (LegoisClear == 0 && BaseballisClear == 1)
        {
            funonoff.Fun_Baseball_On();
        }
        else if (LegoisClear == 1 && BaseballisClear == 1)
        {
            funonoff.FunOn();
        }
    }

    public void FunBaseball(){
        goBaseball.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void FunLego(){
        goLego.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
