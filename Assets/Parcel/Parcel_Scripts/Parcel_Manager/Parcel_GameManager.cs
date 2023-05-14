using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parcel_GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;

    public static Parcel_GameManager instance;

    public bool isStartGame = false;

    Parcel_ComboManager theCombo;
    Parcel_Scoremanager theScore;
    Parcel_TimingManager theTiming;
    Parcel_Ending theEnding;
    Parcel_EffectManager theEffect;
    Parcel_Result theResult;

    void Start()
    {
        instance = this;
        theCombo = FindObjectOfType<Parcel_ComboManager>();
        theScore = FindObjectOfType<Parcel_Scoremanager>();
        theTiming = FindObjectOfType<Parcel_TimingManager>();
        theEnding = FindObjectOfType<Parcel_Ending>();
        theEffect = FindObjectOfType<Parcel_EffectManager>();
        theResult = FindObjectOfType<Parcel_Result>();
    }

    public void OnClickRestart()
    {
        //print("click");
        GameStart();
        theResult.BtnRestart();
    }

    public void GameStart()
    {
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }
        isStartGame = true;
        theCombo.ResetCombo();
        theScore.Initialized();
        theEnding.ResetMusic();
        theTiming.Initialized();
        theTiming.boxNoteList.Clear();
    }

    public void OnClickMainMenu()
    {
        MainMenu();
        theResult.BtnMainMenu();
    }

    public void MainMenu(){
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }
        goTitleUI.SetActive(true);
        
        isStartGame = false;
        theCombo.ResetCombo();
        theScore.Initialized();
        theEnding.ResetMusic();
        theTiming.Initialized();
        theTiming.boxNoteList.Clear();
    }

    public void OnClickStop()
    {
        theEnding.setFalse();
        theEnding.gameTime = 47;
    }
}
