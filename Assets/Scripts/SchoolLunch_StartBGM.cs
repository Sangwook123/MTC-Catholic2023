using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SchoolLunch_StartBGM : MonoBehaviour
{
    AudioSource myAudio;
    SchoolLunch_Result theResult;
    public bool musicStart = false;
    public float gameTime;
    public AudioClip effectSoundO;
    public AudioClip effectSoundX;

    // 남은 시간
    [SerializeField] Text remaining_time = null;
    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;

    private void Start()
    {
        musicStart = false;
        myAudio = GetComponent<AudioSource>();
        theResult = FindObjectOfType<SchoolLunch_Result>();
        
        // 남은 시간
        stopwatch.SetActive(false);
        show_time.SetActive(false);
    }

    void Update()
    {
        if(musicStart)
        {
            gameTime += Time.deltaTime;

            setTrue();

            if (gameTime > 45)            
            {
                theResult.ShowResult();
            }
        }
    }

    public void setTrue(){
        // 남은 시간
        remaining_time.text = string.Format("{0:N2}", 45 - gameTime);// 소수점 두자리까지
        show_time.SetActive(true);
        stopwatch.SetActive(true);
    }

    public void setFalse(){
        // 남은 시간
        stopwatch.SetActive(false);
        show_time.SetActive(false);
    }

    public void MusicStart()//노래 시작 함수
    {
        myAudio.Play();
        musicStart = true;
    }

    public void MusicOff()//노래 정지 함수
    {
        setFalse();
        myAudio.Stop();
        SchoolLunch_GameManager.instance.isStartGame = false;
        musicStart = false;
    }

    public void EffectSoundO()//perfect,cool,good 효과음
    {
        myAudio.PlayOneShot(effectSoundO);
    }

    public void EffectSoundX()//bad,miss 효과음
    {
        myAudio.PlayOneShot(effectSoundX);
    }
}
