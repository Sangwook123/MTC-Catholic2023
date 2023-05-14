using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class base_GameManager : MonoBehaviour
{
    ComboManager theCombo;
    ScoreManager theScore;
    EffectManager theEffect;
    MusicStart theMusic;
    Result theResult;
    TimingManager theTiming;
    TutorialManager theTutorial;

    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;

    public bool isStartGame = false;

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("click");
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
        theEffect.Initialized();
        theMusic.ResetMusic();
        theTiming.Initialized();
        theTutorial.Initialized();
    }

    public void OnClickMainMenu()
    {
        MainMenu();
        theMusic.setFalse();
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

    public void OnClickStop()
    {
        theMusic.setFalse();
        theMusic.gameTime = 46;
    }
}
