using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    [SerializeField] GameObject goBestScoreUI = null;
    [SerializeField] GameObject goScoreUI = null;

    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtScore = null;
    [SerializeField] Text txtBestScore = null;
    [SerializeField] Text txtShowBest = null;

    ScoreManager theScore;
    ComboManager theCombo;
    EffectManager theEffect;
    MusicStart theMusic;
    TutorialManager theTutorial;
    TeacherController theTeacher;
    NoteManager theNote;

    public bool ResultIs = false;

    public AudioSource theendingSound;

    public int[] t_judgement;
    public int t_currentScore;
    public int bestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt ("BestScore_base", (PlayerPrefs.GetInt ("BestScore_base", 0)));

        theScore = FindObjectOfType<ScoreManager>();
        theCombo = FindObjectOfType<ComboManager>();
        theEffect = FindObjectOfType<EffectManager>();
        theMusic = FindObjectOfType<MusicStart>();
        theTutorial = FindObjectOfType<TutorialManager>();
        theTeacher = FindObjectOfType<TeacherController>();
        theendingSound = GetComponent<AudioSource>();
        theNote = FindObjectOfType<NoteManager>();
    }

    public void ShowResult()
    {
        FindObjectOfType<MusicStart>().ResetMusic();

        goUI.SetActive(true);
        goBestScoreUI.SetActive(false);
        goScoreUI.SetActive(false);
        ResultIs = true;
            
        if(ResultIs) theendingSound.Play();

        for (int i = 0; i < 5; i++)
        {
            txtCount[i].text = "0";
        }

        txtScore.text = "0";

        // 점수 저장
        t_judgement = theEffect.GetJudgementRecord();
        t_currentScore = theScore.GetCurrentScore();

        theNote.RemoveNote();

        if(t_currentScore > PlayerPrefs.GetInt("BestScore_base")){
            BestScore();
        }
        else{
            justScore();
        }
    }

    // 최고 점수 갱신
    public void BestScore(){
        PlayerPrefs.SetInt ("BestScore_base", t_currentScore);
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_base"));
        txtShowBest.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_base"));
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
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_base"));
        txtScore.text = string.Format("{0:#,##0}", t_currentScore);

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
