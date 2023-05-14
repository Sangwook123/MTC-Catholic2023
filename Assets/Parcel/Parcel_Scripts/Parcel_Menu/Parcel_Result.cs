using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parcel_Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    [SerializeField] GameObject goBestScoreUI = null;
    [SerializeField] GameObject goScoreUI = null;


    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtScore = null;
    [SerializeField] Text txtBestScore = null;
    [SerializeField] Text txtShowBest = null;

    [SerializeField] public AudioSource[] bgm = null;

    Parcel_Scoremanager theScore;
    Parcel_ComboManager theCombo;
    Parcel_TimingManager theTiming;
    Parcel_Ending theEnding;
    Parcel_Tutorial theTutorial;
    Parcel_NoteManager theNoteManager;
    Parcel_PlayerController thePlayer;

    public bool ResultIs = false;

    public int[] t_judgement;
    public int t_currentScore;
    public int bestScore = 0;

   // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt ("BestScore_parcel", (PlayerPrefs.GetInt ("BestScore_parcel", 0)));

        theScore = FindObjectOfType<Parcel_Scoremanager>();
        theCombo = FindObjectOfType<Parcel_ComboManager>();
        theTiming = FindObjectOfType<Parcel_TimingManager>();
        theEnding = FindObjectOfType<Parcel_Ending>();
        theTutorial = FindObjectOfType<Parcel_Tutorial>();
        theNoteManager = FindObjectOfType<Parcel_NoteManager>();
        thePlayer = FindObjectOfType<Parcel_PlayerController>();
        
    }

    public void ShowResult() 
    {
        thePlayer.canPressKey = false;
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

        if(t_currentScore > PlayerPrefs.GetInt("BestScore_parcel")){
            BestScore();
        }
        else{
            justScore();
        }
    }

    // 최고 점수 갱신
    public void BestScore(){
        PlayerPrefs.SetInt ("BestScore_parcel", t_currentScore);
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_parcel"));
        txtShowBest.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_parcel"));
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
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_parcel"));
        txtScore.text = string.Format("{0:#,##0}", t_currentScore);

        goScoreUI.SetActive(true);
    }

    public void BtnRestart()
    {
        theEnding.gameTime = 0f;
        theNoteManager.currentTime = 0f;
        theEnding.isGameOver = false;
        goUI.SetActive(false);
        theCombo.ResetCombo();
        theTutorial.ShowTutorial();
        ResultIs = false;
    }

    public void BtnMainMenu()
    {
        theEnding.gameTime = 0f;
        theNoteManager.currentTime = 0f;
        theEnding.isGameOver = false;
        theTutorial.ShowTutorial();
        theCombo.ResetCombo();
        ResultIs = false;
        goUI.SetActive(false);
    }
}
