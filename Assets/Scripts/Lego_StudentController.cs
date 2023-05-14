using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using TMPro;

public class Lego_StudentController : MonoBehaviour
{
    Animator anim;
    public bool isTouching;
    Lego_TutorialManager theTutorial;

    AudioSource myaudio;
    public float clicktime;

  



    // Start is called before the first frame update
    void Awake()
    {
        myaudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        theTutorial = FindObjectOfType<Lego_TutorialManager>();
    }

  
    // Update is called once per frame
    void Update()
    {
     
        if(theTutorial.TutorialIs == false)
        {
            //마우스를 클릭하고 있으면
            if (Input.GetMouseButtonDown(0))
            {
                myaudio.Play();
                //Debug.Log("clicking");
                anim.SetBool("Touching", true);
                isTouching = true;
                clicktime = Time.time;
            }

            //마우스를 클릭하고 있다가 떼면
            else if (Input.GetMouseButtonUp(0))
            {
                //Debug.Log("Endclicking");
                anim.SetBool("Touching", false);
                isTouching = false;
                clicktime = 0.0f;
            }
        }
        

    }

   


}