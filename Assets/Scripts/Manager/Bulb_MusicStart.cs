using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulb_MusicStart : MonoBehaviour
{
    public AudioSource myAudio;
    public bool musicStart = false;

    Bulb_Result theResult;
    BulbManager theBulbManager;

    public bool musicStop = false;

    public float gameTime;
    public bool isGameOver;

    Bulb_TutorialManager theTutorial;
    Bulb_GameManager theGame;
    BulbManager theBulb;
    Bulb_TimingManager theTimingManager;

    // 남은 시간
    [SerializeField] Text remaining_time = null;
    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        theResult = FindObjectOfType<Bulb_Result>();
        theBulbManager = FindObjectOfType<BulbManager>();
        theGame = FindObjectOfType<Bulb_GameManager>();
        theBulb = FindObjectOfType<BulbManager>();
        theTimingManager = GetComponent<Bulb_TimingManager>();

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
        if (musicStart)
        {
            gameTime += Time.deltaTime;
            // 남은 시간
            show_time.SetActive(true);
            stopwatch.SetActive(true);

            if (gameTime > 45)
            {
                isGameOver = true;
                remaining_time.text = string.Format("00:00");// 소수점 두자리까지
            }
            else{
                remaining_time.text = string.Format("{0:N2}", 45 - gameTime);// 소수점 두자리까지
            }

            if (gameTime > 47)
            {
                setFalse();
                stopMusic();   
            }
        }
    }

    public void stopMusic(){
        musicStart = false;
        theGame.isStartGame = false;
        isGameOver = true;
        myAudio.Stop();
        theResult.ShowResult();
        gameTime = 0;
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
            if (collision.CompareTag("Red_bulb") || collision.CompareTag("Blue_bulb")
                || collision.CompareTag("Yellow_bulb"))
            {
                myAudio.Play();
                musicStart = true;
            }
        }
    }
}