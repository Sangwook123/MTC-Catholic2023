using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run_GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;

    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    public static Run_GameManager instance;

    public bool isStartGame = false;
    public bool isStop = false;

    Run_ComboManager theCombo;
    Run_Scoremanager theScore;
    Run_TimingManager theTiming;
    Run_Ending theEnding;
    Run_Player thePlayer;
    Run_EffectManager theEffect;
    Run_Result theResult;

    void Start()
    {
        instance = this;
        theCombo = FindObjectOfType<Run_ComboManager>();
        theScore = FindObjectOfType<Run_Scoremanager>();
        theTiming = FindObjectOfType<Run_TimingManager>();
        theEnding = FindObjectOfType<Run_Ending>();
        theEffect = FindObjectOfType<Run_EffectManager>();
        thePlayer = FindObjectOfType<Run_Player>();
        theResult = FindObjectOfType<Run_Result>();
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

    public void GameReset(){
        isStartGame = false;
        theCombo.ResetCombo();
        theScore.Initialized();
        theEnding.ResetMusic();
        theTiming.Initialized();
        theTiming.boxNoteList.Clear();
    }

    public void MainMenu(){
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }
        goTitleUI.SetActive(true);
        GameReset();
    }


    public void OnClickMainMenu()
    {
        MainMenu();
        theResult.BtnMainMenu();
        isStop = false;
    }

    public void OnClickRestart()
    {
        GameStart();
        theResult.BtnRestart();
        isStop = false;
    }

    public void OnClickStop(){
        isStop = true;
        Debug.Log("stop");
        stopwatch.SetActive(false);
        show_time.SetActive(false);
        theEnding.stopMusic();
    }
}
