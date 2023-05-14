using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using TMPro;

public class StudentController : MonoBehaviour
{
    Animator anim;
    public bool isTouching;
    public AudioSource myAudio;

    TutorialManager theTutorial;
    TimingManager theTimingManager;
    MusicStart theMusic;

    public float fDestroyTime = 1f;
    public float fTickTime;

    // Start is called before the first frame update
    void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        theTutorial = FindObjectOfType<TutorialManager>();
        theTimingManager = FindObjectOfType<TimingManager>();
        theMusic = FindObjectOfType<MusicStart>();
    }

    // Update is called once per frame
    void Update()
    {
        if((theTutorial.TutorialIs == false) && (theMusic.musicStart == true))
        {
            // 1초 뒤에 실행
            if(theMusic.gameTime >= 1){
                Debug.Log("START : " + fTickTime);
                // 판정체크            
                if (Input.GetMouseButtonDown(0))
                {
                    theTimingManager.CheckTiming();
                    myAudio.Play();
                    anim.SetBool("Touching", true);
                    isTouching = true;
                }
                else if (Input.GetMouseButtonUp(0)){
                    anim.SetBool("Touching", false);
                    isTouching = false;
                }
            }
        }   
    }
}
