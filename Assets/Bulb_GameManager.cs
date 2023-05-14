using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bulb_GameManager : MonoBehaviour
{
    Bulb_ComboManager theCombo;
    Bulb_ScoreManager theScore;
    Bulb_EffectManager theEffect;
    Bulb_MusicStart theMusic;
    Bulb_Result theResult;
    BulbManager theBulb;

    public static Bulb_GameManager instance;

    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;

    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    public bool isStartGame = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theCombo = FindObjectOfType<Bulb_ComboManager>();
        theScore = FindObjectOfType<Bulb_ScoreManager>();
        theEffect = FindObjectOfType<Bulb_EffectManager>();
        theMusic = FindObjectOfType<Bulb_MusicStart>();
        theResult = FindObjectOfType<Bulb_Result>();
        theBulb = FindObjectOfType<BulbManager>();
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
        theEffect.Initialized();
        theMusic.ResetMusic();
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
        theEffect.Initialized();
        theMusic.ResetMusic();
    }

    public void OnClickMainMenu()
    {
        theBulb.RemoveNote();
        MainMenu();
        theResult.BtnRestart();
        theResult.BtnMainMenu();
        stopwatch.SetActive(false);
        show_time.SetActive(false);
    }

    public void OnClickRestart()
    {
        theBulb.RemoveNote();
        //print("click");
        GameStart();
        theResult.BtnRestart();
        stopwatch.SetActive(false);
        show_time.SetActive(false);   
    }

    public void OnClickStop(){
        Debug.Log("stop");
        theBulb.RemoveNote();
        theMusic.gameTime = 48;
        //theMusic.stopMusic();
        //theEnding.stopMusic();
    }
}
