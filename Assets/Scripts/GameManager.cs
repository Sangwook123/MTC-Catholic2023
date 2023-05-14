using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    ComboManager theCombo;
    ScoreManager theScore;
    EffectManager theEffect;
    MusicStart theMusic;
    Result theResult;
    TimingManager theTiming;
    TutorialManager theTutorial;

    public static GameManager instance;

    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;
    public bool isStartGame = false;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theCombo = FindObjectOfType<ComboManager>();
        theScore = FindObjectOfType<ScoreManager>();
        theEffect = FindObjectOfType<EffectManager>();
        theMusic = FindObjectOfType<MusicStart>();
        theResult = FindObjectOfType<Result>();
        theTiming = FindObjectOfType<TimingManager>();
        theTutorial = FindObjectOfType<TutorialManager>();
    }

    public void OnClickRestart()
    {
        GameStart();
        theResult.BtnRestart();
    }

    public void GameStart()
    {
        //goTitleUI.SetActive(false);
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }
        isStartGame = true;

        theCombo.ResetCombo();
        theScore.Initialized();
        theEffect.Initialized();
        theMusic.ResetMusic();
        theTiming.Initialized();
        theTutorial.Initialized();
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
        theEffect.Initialized();
        theMusic.ResetMusic();
        theTiming.Initialized();
        theTutorial.Initialized();
    }
}
