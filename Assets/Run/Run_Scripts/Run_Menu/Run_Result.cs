using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run_Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    [SerializeField] GameObject goBestScoreUI = null;
    [SerializeField] GameObject goScoreUI = null;


    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtScore = null;
    [SerializeField] Text txtBestScore = null;
    [SerializeField] Text txtShowBest = null;

    [SerializeField] public AudioSource[] bgm = null;

    Run_Scoremanager theScore;
    Run_ComboManager theCombo;
    Run_TimingManager theTiming;
    Run_Ending theEnding;
    Run_Tutorial theTutorial;
    Run_NoteManager theNoteManager;
    Run_Player thePlayer;

    public bool ResultIs = false;

    public int[] t_judgement;
    public int t_currentScore;
    public int bestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt ("BestScore_run", (PlayerPrefs.GetInt ("BestScore_run", 0)));

        theScore = FindObjectOfType<Run_Scoremanager>();
        theCombo = FindObjectOfType<Run_ComboManager>();
        theTiming = FindObjectOfType<Run_TimingManager>();
        theEnding = FindObjectOfType<Run_Ending>();
        theTutorial = FindObjectOfType<Run_Tutorial>();
        theNoteManager = FindObjectOfType<Run_NoteManager>();
        thePlayer = FindObjectOfType<Run_Player>();
    }

    public void ShowResult()
    {
        thePlayer.presskey = false;
        ResultIs = true;
        bgm[0].Play(); 

        goUI.SetActive(true);
        goBestScoreUI.SetActive(false);
        goScoreUI.SetActive(false);

        for (int i = 0; i < txtCount.Length; i++){
            txtCount[i].text = "0";
        }

        txtScore.text = "0";

        t_judgement = theTiming.GetJudgementRecord();
        t_currentScore = theScore.GetCurrentScore();

        theNoteManager.RemoveNote();

        if(t_currentScore > PlayerPrefs.GetInt("BestScore_run")){
            BestScore();
        }
        else{
            justScore();
        }
    }

    // 최고 점수 갱신
    public void BestScore(){
        PlayerPrefs.SetInt ("BestScore_run", t_currentScore);
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_run"));
        txtShowBest.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_run"));
        PlayerPrefs.Save();

        goBestScoreUI.SetActive(true);
    }

    // 현재 점수
    public void justScore(){
        goBestScoreUI.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            txtCount[i].text = string.Format("{0:#,##0}", t_judgement[i]);
        }

        if((Run_GameManager.instance.isStop == true) && (t_judgement[4] > 0))
        {
            txtCount[4].text = string.Format("{0:#,##0}", t_judgement[4]-1);
        }

        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_run"));
        txtScore.text = string.Format("{0:#,##0}", t_currentScore);

        goScoreUI.SetActive(true);
    }

    public void BtnRestart()
    {
        theEnding.gameTime = 0f;
        theNoteManager.currentTime = 0f;
        theEnding.isGameOver = false;
        theCombo.ResetCombo();
        
        ResultIs = false;
        goUI.SetActive(false);

        theTutorial.TutorialIs = true;
        theTutorial.ShowTutorial();
    }

    public void BtnMainMenu()
    {
        theEnding.gameTime = 0f;
        theNoteManager.currentTime = 0f;
        theEnding.isGameOver = false;
        theCombo.ResetCombo();
        
        ResultIs = false;
        goUI.SetActive(false);

        theTutorial.TutorialIs = true;
        theTutorial.ShowTutorial();
    }
}

