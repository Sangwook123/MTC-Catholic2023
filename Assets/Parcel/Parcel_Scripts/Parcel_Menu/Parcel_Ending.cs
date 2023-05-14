using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parcel_Ending : MonoBehaviour
{

    public AudioSource myAudio;
    public bool musicStart = false;

    Parcel_Result theResult;
    Parcel_NoteManager theBulbManager;

    public bool musicStop = false;

    public float gameTime;
    public bool isGameOver;

    Parcel_Tutorial theTutorial;
    Parcel_GameManager theGame;
    Parcel_NoteManager theNote;
    Parcel_PlayerController thePlayer;

    // 남은 시간
    [SerializeField] Text remaining_time = null;
    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        theResult = FindObjectOfType<Parcel_Result>();
        theBulbManager = FindObjectOfType<Parcel_NoteManager>();
        theGame = FindObjectOfType<Parcel_GameManager>();
        theNote = FindObjectOfType<Parcel_NoteManager>();
        thePlayer = FindObjectOfType<Parcel_PlayerController>();

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
                remaining_time.text = string.Format("00:00");
            }
            else{
                remaining_time.text = string.Format("{0:N2}", 45 - gameTime);// 소수점 두자리까지            }
            }

            if (gameTime > 47)
            {
                setFalse();                

                ResetMusic();
                myAudio.Stop();
                theResult.ShowResult();
                gameTime = 0;
            }
        }
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
            if (collision.CompareTag("Note") || collision.CompareTag("house"))
            {
                myAudio.Play();
                musicStart = true;
                thePlayer.canPressKey = true;
            }
        }
    }
}