using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lego_Result : MonoBehaviour
{

    [SerializeField] GameObject goUI = null;
    [SerializeField] GameObject goBestScoreUI = null;
    [SerializeField] GameObject goScoreUI = null;

    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtScore = null;
    [SerializeField] Text txtBestScore = null;
    [SerializeField] Text txtShowBest = null;

    Lego_ScoreMananger theScore;
    Lego_ComboManager theCombo;
    Lego_EffectMananger theEffect;
    Lego_MusicStart theMusic;
    Lego_TutorialManager theTutorial;
    Lego_TeacherController theTeacher;

    public bool ResultIs = false;

    public AudioSource endingSound;

    public int[] t_judgement;
    public int t_currentScore;
    public int bestScore;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("BestScore_lego", (PlayerPrefs.GetInt("BestScore_lego", 0)));

        theScore = FindObjectOfType<Lego_ScoreMananger>();
        theCombo = FindObjectOfType<Lego_ComboManager>();
        theEffect = FindObjectOfType<Lego_EffectMananger>();
        theMusic = FindObjectOfType<Lego_MusicStart>();
        theTutorial = FindObjectOfType<Lego_TutorialManager>();
        theTeacher = FindObjectOfType<Lego_TeacherController>();
        endingSound = GetComponent<AudioSource>();
    }

    public void ShowResult()
    {
        FindObjectOfType<Lego_MusicStart>().ResetMusic();

        goUI.SetActive(true);
        goBestScoreUI.SetActive(false);
        goScoreUI.SetActive(false);
        ResultIs = true;

        for (int i = 0; i < 5; i++)
        {
            txtCount[i].text = "0";
        }

        txtScore.text = "0";

        // 점수 저장
        t_judgement = theEffect.GetJudgementRecord();
        t_currentScore = theScore.GetCurrentScore();

        if (t_currentScore > PlayerPrefs.GetInt("BestScore_lego"))
        {
            BestScore();
        }
        else
        {
            justScore();
        }
        Debug.Log(t_currentScore);
        Debug.Log(PlayerPrefs.GetInt("BestScore_lego"));
    }

    // 최고 점수 갱신
    public void BestScore()
    {
        PlayerPrefs.SetInt("BestScore_lego", t_currentScore);
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_lego"));
        txtShowBest.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_lego"));
        PlayerPrefs.Save();

        goBestScoreUI.SetActive(true);
    }

    // 현재 점수
    public void justScore()
    {
        goBestScoreUI.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            txtCount[i].text = string.Format("{0:#,##0}", t_judgement[i]);
        }
        txtScore.text = string.Format("{0:#,##0}", t_currentScore);
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_lego"));

        goScoreUI.SetActive(true);
    }

    public void BtnRestart()
    {
        theMusic.gameTime = 0f;
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
        theCombo.ResetCombo();
        theTutorial.ShowTutorial();
        goUI.SetActive(false);
        ResultIs = false;
    }
}