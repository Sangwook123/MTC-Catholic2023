using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lego_GameManager : MonoBehaviour
{
    Lego_ComboManager theCombo;
    Lego_ScoreMananger theScore;
    Lego_EffectMananger theEffect;
    Lego_MusicStart theMusic;
    Lego_Result theResult;
    Lego_TeacherController theTeacher;
    Lego_TutorialManager theTutorial;

    public static Lego_GameManager instance;

    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;
    public bool isStartGame = false;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theCombo = FindObjectOfType<Lego_ComboManager>();
        theScore = FindObjectOfType<Lego_ScoreMananger>();
        theEffect = FindObjectOfType<Lego_EffectMananger>();
        theMusic = FindObjectOfType<Lego_MusicStart>();
        theResult = FindObjectOfType<Lego_Result>();
        theTeacher = FindObjectOfType<Lego_TeacherController>();
        theTutorial = FindObjectOfType<Lego_TutorialManager>();
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
        theEffect.Initialized();
        theMusic.ResetMusic();
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

        theTutorial.Initialized();
        theCombo.ResetCombo();
        theScore.Initialized();
        theEffect.Initialized();
        theMusic.ResetMusic();
    }

    public void OnClickStop()
    {
        theMusic.setFalse();
        theMusic.gameTime = 48;
    }
}
