using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lego_MusicStart : MonoBehaviour
{
    public AudioSource myAudio;
    public bool musicStart = false;
    public bool musicStop = false;

    Lego_Result theResult;

    public float gameTime;
    public bool isGameOver;

    Lego_TutorialManager theTutorial;

    // 남은 시간
    [SerializeField] Text remaining_time = null;
    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        theResult = FindObjectOfType<Lego_Result>();
        theTutorial = FindObjectOfType<Lego_TutorialManager>();
        myAudio.playOnAwake = false;

        // 남은 시간
        stopwatch.SetActive(false);
        show_time.SetActive(false);
    }

    public void ResetMusic()
    {
        musicStart = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(musicStart)
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
                ResetMusic();
                myAudio.Stop();
                theResult.endingSound.Play();
                theResult.ShowResult();
                gameTime = 0;

                setFalse();
            }
        }
    }

    public void setFalse(){
        // 남은 시간
        stopwatch.SetActive(false);
        show_time.SetActive(false);
    }
}