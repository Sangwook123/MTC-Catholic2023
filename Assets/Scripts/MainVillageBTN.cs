using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVillageBTN : MonoBehaviour
{
    [SerializeField] GameObject goFunvi = null;
    [SerializeField] GameObject goConvi = null;
    [SerializeField] GameObject goHealvi = null;
    [SerializeField] GameObject goBtnUI = null;

    public int Lego;
    public int Baseball;
    public int parcel;
    public int bulb;
    public int cafe;
    public int run;
    public int sum = 0;

    public void Update(){
        Lego = PlayerPrefs.GetInt("legoisclear");
        Baseball = PlayerPrefs.GetInt("baseballisclear");
        run = PlayerPrefs.GetInt("runisclear");
        cafe = PlayerPrefs.GetInt("cafeteriaisclear");
        bulb = PlayerPrefs.GetInt("bulbisclear");
        parcel = PlayerPrefs.GetInt("parcelisclear");

        sum = Lego + Baseball + parcel + bulb + cafe + run;

        if(this.gameObject.activeSelf){
            if(sum == 6){
                goBtnUI.SetActive(true);
            }
            else{
                goBtnUI.SetActive(false);
            }
        }
    }

    public void Funvi(){
        goFunvi.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Convi(){
        goConvi.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Healvi(){
        goHealvi.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
