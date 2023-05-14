using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLunch_GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;
    [SerializeField] GameObject noteUI = null;

    public static SchoolLunch_GameManager instance;
    public bool isStartGame = false;//게임시작 변수(상태확인)
    public bool isStartTutorial = false;//튜토리얼 변수(상태확인)

    SchoolLunch_NoteManeger theNote;
    SchoolLunch_ComboManager theCombo;
    SchoolLunch_ScoreManager theScore;
    SchoolLunch_EffectManager theEffect;
    SchoolLunch_StartBGM theBGM;
    SchoolLunch_Result theResult;
    SchoolLunch_Tutorial theTutorial;
    SchoolLunch_ObjectPool theObject;

    void Start()
    {
        isStartTutorial = true;
        instance = this;
        theNote = FindObjectOfType<SchoolLunch_NoteManeger>();
        theCombo = FindObjectOfType<SchoolLunch_ComboManager>();
        theScore = FindObjectOfType<SchoolLunch_ScoreManager>();
        theEffect = FindObjectOfType<SchoolLunch_EffectManager>();
        theBGM = FindObjectOfType<SchoolLunch_StartBGM>();
        theTutorial = FindObjectOfType<SchoolLunch_Tutorial>();
        theResult = FindObjectOfType<SchoolLunch_Result>();
        theObject = FindObjectOfType<SchoolLunch_ObjectPool>();
    }
    
    public void GameStart()// 게임 시작
    {
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }
        isStartGame = true;
        theBGM.MusicStart();
        theScore.ScoreShow();
    }

    public void GameReset(){
        isStartGame = false;
        theNote.Initialized();
        theCombo.ResetCombo();
        theScore.Initialized();
        theEffect.Initialized();
        //theResult.ShowResult();
        theNote.RemoveNote();
    }

    public void mainmenu(){
        for(int i=0;i<goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }
        goTitleUI.SetActive(true);
        GameReset();
    }

    public void OnClickMainMenu()
    {
        Debug.Log("mainmenu");
        mainmenu();
        theResult.ButtonMainMenu();
        
    }
    
    public void OnClickRestart()
    {
        Debug.Log("restart");
        GameReset();
        theResult.ButtonRestart();
    }

    public void OnClickStop(){
        Debug.Log("stop");
        theNote.RemoveNote();
        theBGM.gameTime = 45f;
        //theResult.ShowResult();
    }
}