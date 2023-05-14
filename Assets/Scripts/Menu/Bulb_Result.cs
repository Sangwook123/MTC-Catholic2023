using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulb_Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    [SerializeField] GameObject goBestScoreUI = null;
    [SerializeField] GameObject goScoreUI = null;

    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtScore = null;
    [SerializeField] Text txtBestScore = null;
    [SerializeField] Text txtShowBest = null;

    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    Bulb_ScoreManager theScore;
    Bulb_ComboManager theCombo;
    Bulb_EffectManager theEffect;
    Bulb_MusicStart theMusic;
    Bulb_TutorialManager theTutorial;
    BulbManager theBulb;

    public bool ResultIs = false;

    public AudioSource endingSound;

    public int[] t_judgement;
    public int t_currentScore;
    public int bestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt ("BestScore_bulb", (PlayerPrefs.GetInt ("BestScore_bulb", 0)));

        theScore = FindObjectOfType<Bulb_ScoreManager>();
        theCombo = FindObjectOfType<Bulb_ComboManager>();
        theEffect = FindObjectOfType<Bulb_EffectManager>();
        theMusic = FindObjectOfType<Bulb_MusicStart>();
        theTutorial = FindObjectOfType<Bulb_TutorialManager>();
        theBulb = FindObjectOfType<BulbManager>();
        endingSound = FindObjectOfType<AudioSource>();
    }

    public void ShowResult()
    {
        stopwatch.SetActive(false);
        show_time.SetActive(false);

        endingSound.Play();
        goUI.SetActive(true);
        goBestScoreUI.SetActive(false);
        goScoreUI.SetActive(false);

        ResultIs = true;

        for (int i = 0; i < 5; i++)
        {
            txtCount[i].text = "0"; 
        }

        txtScore.text = "0";


        t_judgement = theEffect.GetJudgementRecord();
        t_currentScore = theScore.GetCurrentScore();

        if(t_currentScore > PlayerPrefs.GetInt("BestScore_bulb")){
            BestScore();
        }
        else{
            justScore();
        }
    }

    // 최고 점수 갱신
    public void BestScore(){
        PlayerPrefs.SetInt ("BestScore_bulb", t_currentScore);
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_bulb"));
        txtShowBest.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_bulb"));
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
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_bulb"));
        txtScore.text = string.Format("{0:#,##0}", t_currentScore);

        goScoreUI.SetActive(true);
    }

    public void BtnRestart()
    {
        endingSound.Stop();
        theMusic.gameTime = 0f;
        theBulb.currentTime = 0f;
        theMusic.isGameOver = false;
        goUI.SetActive(false);
        theCombo.ResetCombo();
        theTutorial.ShowTutorial();
        ResultIs = false;
    }

    public void BtnMainMenu()
    {
        theMusic.gameTime = 0f;
        theMusic.isGameOver = false;
        goUI.SetActive(false);
        goUI.SetActive(false);
    }
}
