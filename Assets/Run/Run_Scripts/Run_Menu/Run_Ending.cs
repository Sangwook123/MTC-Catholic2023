using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run_Ending : MonoBehaviour
{

    public AudioSource myAudio;
    public bool musicStart = false;

    Run_Result theResult;
    Run_NoteManager theBulbManager;

    public bool musicStop = false;

    public float gameTime;
    public bool isGameOver;

    Run_Tutorial theTutorial;
    Run_GameManager theGame;
    Run_NoteManager theNote;
    Run_Player thePlayer;
    
    // 남은 시간
    [SerializeField] Text remaining_time = null;
    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        theResult = FindObjectOfType<Run_Result>();
        theBulbManager = FindObjectOfType<Run_NoteManager>();
        theGame = FindObjectOfType<Run_GameManager>();
        theNote = FindObjectOfType<Run_NoteManager>();
        thePlayer = FindObjectOfType<Run_Player>();

        // 남은 시간
        stopwatch.SetActive(false);
        show_time.SetActive(false);
    }

    public void ResetMusic()
    {
        musicStart = false;
        isGameOver = false;
    }

    void Update()
    {
        if(musicStart && Run_GameManager.instance.isStartGame)
        {
            gameTime += Time.deltaTime;

            // 남은 시간
            show_time.SetActive(true);
            stopwatch.SetActive(true);

            if (gameTime > 45)
            {
                isGameOver = true;
                remaining_time.text = string.Format("00:00");
            }
            else{
                remaining_time.text = string.Format("{0:N2}", 45 - gameTime);// 소수점 두자리까지            }
            }

            if (gameTime > 47)
            {
                setFalse();
                stopMusic();   
            }
        }
    }

    public void stopMusic(){
        Run_GameManager.instance.isStartGame = false;
        isGameOver = true;
        myAudio.Stop();
        gameTime = 0;
        theResult.ShowResult();
    }

    public void setFalse(){
        // 남은 시간
        stopwatch.SetActive(false);
        show_time.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            if (collision.CompareTag("Note"))
            {
                myAudio.Play();
                musicStart = true;
                thePlayer.presskey = true;
            }
        }
    }
}
