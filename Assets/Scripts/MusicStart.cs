using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicStart : MonoBehaviour
{
    public AudioSource myAudio;
    public bool musicStart = false;
    public bool musicStop = false;

    Result theResult;

    public float gameTime;
    public bool isGameOver;

    TutorialManager theTutorial;
    NoteManager theNote;

    // 남은 시간
    [SerializeField] Text remaining_time = null;
    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        theResult = FindObjectOfType<Result>();
        theTutorial = FindObjectOfType<TutorialManager>();
        theNote = FindObjectOfType<NoteManager>();
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
            remaining_time.text = string.Format("{0:N2}", 45 - gameTime);// 소수점 두자리까지
            show_time.SetActive(true);
            stopwatch.SetActive(true);

            if (gameTime > 45){
                stopMusic();
            }
        }
    }

    public void stopMusic(){
        isGameOver = true;
        myAudio.Stop();
        theResult.ShowResult();
        gameTime = 0;
        theNote.RemoveNote();

        setFalse();   
    }

    public void setFalse(){
        // 남은 시간
        stopwatch.SetActive(false);
        show_time.SetActive(false);
    }
}
