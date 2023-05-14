using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConVillBtn : MonoBehaviour
{
    [SerializeField] GameObject goBulb = null;
    [SerializeField] GameObject goDelievery = null;

    ConOnOff cononoff;

    public int BulbisClear;
    public int ParcelisClear;

    void Start()
    {
        cononoff = FindObjectOfType<ConOnOff>();
       
        /*PlayerPrefs.SetInt("bulbisclear", 0);
        PlayerPrefs.SetInt("parcelisclear", 0); */
        // 여기까지
    }

    void Update()
    {
        BulbisClear = PlayerPrefs.GetInt("bulbisclear");
        ParcelisClear = PlayerPrefs.GetInt("parcelisclear");

        if (BulbisClear == 1 && ParcelisClear == 0)
        {
            cononoff.Con_Bulb_On();
        }
        else if (BulbisClear == 0 && ParcelisClear == 1)
        {
            cononoff.Con_Parcel_On();
        }
        else if (BulbisClear == 1 && ParcelisClear == 1)
        {
            cononoff.ConOn();
        }



    }

    public void ConBulb(){
        goBulb.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ConDelievery(){
        goDelievery.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
