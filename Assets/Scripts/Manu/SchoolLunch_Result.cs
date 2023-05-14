using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//결과창
public class SchoolLunch_Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    [SerializeField] GameObject goBestScoreUI = null;
    [SerializeField] GameObject goScoreUI = null;
    [SerializeField] GameObject noteUI = null;

    [SerializeField]GameObject GameClear = null;
    [SerializeField]GameObject GameOver = null;
    [SerializeField]GameObject goGameUI = null;
    [SerializeField]GameObject goTitleUI = null;

    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtScore = null;
    [SerializeField] Text txtBestScore = null;
    [SerializeField] Text txtShowBest = null;

    SchoolLunch_ScoreManager theScore;
    SchoolLunch_EffectManager theEffect;
    SchoolLunch_StartBGM theBGM;
    TutorialManager theTutorial;
    SchoolLunch_NoteManeger theNote;
    SchoolLunch_ObjectPool theOBPool;

    AudioSource EndingSound;

    public int[] t_judgement;
    public int t_currentScore;
    public int bestScore = 0;

    void Start()
    {
        PlayerPrefs.SetInt ("BestScore_cafe", (PlayerPrefs.GetInt ("BestScore_cafe", 0)));

        theScore = FindObjectOfType<SchoolLunch_ScoreManager>();
        theEffect = FindObjectOfType<SchoolLunch_EffectManager>();
        theBGM = FindObjectOfType<SchoolLunch_StartBGM>();
        EndingSound = GetComponent<AudioSource>();
        theTutorial = FindObjectOfType<TutorialManager>();
        theOBPool = FindObjectOfType<SchoolLunch_ObjectPool>();
    }

    public void ShowResult()//결과창 보이도록
    {
        theBGM.MusicOff();

        EndingSound.Play();
        goUI.SetActive(true); // 검은색 BackGround
        goBestScoreUI.SetActive(false); // BestScore 갱신 화면
        goScoreUI.SetActive(false); // 결과창 BackGround

        for(int i = 0; i < txtCount.Length; i++)
        {
            txtCount[i].text = "0";
        }

        txtScore.text = "0";

        // 점수 저장
        t_judgement = theEffect.GetJudgementRecord();
        t_currentScore = theScore.GetCurrentScore();

        if(t_currentScore > PlayerPrefs.GetInt("BestScore_cafe")){
            BestScore();
        }
        else{
            justScore();
        }
    }

    // 최고 점수 갱신
    public void BestScore(){
        PlayerPrefs.SetInt ("BestScore_cafe", t_currentScore);
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_cafe"));
        txtShowBest.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_cafe"));
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
        txtBestScore.text = string.Format("{0:#,##0}", PlayerPrefs.GetInt("BestScore_cafe"));
        txtScore.text = string.Format("{0:#,##0}", t_currentScore);

        if(t_currentScore >= 500)
        {
            GameClear.SetActive(true);
            GameOver.SetActive(false);
            PlayerPrefs.SetInt("cafeteriaisclear", 1);
            PlayerPrefs.Save();
        }
        else
        {
            GameOver.SetActive(true);
            GameClear.SetActive(false);
        }

        goScoreUI.SetActive(true);
    }

    // 다시시작 버튼 눌렀을 때
    public void ButtonRestart()
    {
        EndingSound.Stop();
        SchoolLunch_GameManager.instance.isStartTutorial = true;
        theBGM.gameTime = 0f;
        goUI.SetActive(false);
        GameClear.SetActive(false);
        GameOver.SetActive(false);
        theTutorial.ShowTutorial();

        theBGM.MusicOff();
    }

    // 메인메뉴 버튼 눌렀을 때
    public void ButtonMainMenu() 
    {
        SchoolLunch_GameManager.instance.isStartTutorial = true;
        theBGM.gameTime = 0f;
        goUI.SetActive(false);
        GameClear.SetActive(false);
        GameOver.SetActive(false);
        theTutorial.ShowTutorial();

        theBGM.MusicOff();
    }
}
