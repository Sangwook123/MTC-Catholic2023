using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealVillBtn : MonoBehaviour
{
    [SerializeField] GameObject goCafe = null;
    [SerializeField] GameObject goRun = null;

    HealOnOff healonoff;

    public int RunisClear;
    public int CafeteriaisClear;

    void Start()
    {

        /*PlayerPrefs.SetInt("runisclear", 0);
        PlayerPrefs.SetInt("cafeteriaisclear", 0);*/
        // 여기까지
        healonoff = FindObjectOfType<HealOnOff>();
    }

    void Update()
    {
        RunisClear = PlayerPrefs.GetInt("runisclear");
        CafeteriaisClear = PlayerPrefs.GetInt("cafeteriaisclear");

        if (RunisClear == 1 && CafeteriaisClear == 0)
        {
            healonoff.Heal_Run_On();
        }
        else if (RunisClear == 0 && CafeteriaisClear == 1)
        {
            healonoff.Heal_Cafeteria_On();
        }
        else if (RunisClear == 1 && CafeteriaisClear == 1)
        {
            healonoff.HealOn();
        }

    }

    public void HealCafe(){
        goCafe.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void HealRun(){
        goRun.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
