using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class student_controller : MonoBehaviour
{
    Animator anim;
    public bool isTouching;
    TutorialManager theTutorial;
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        theTutorial = FindObjectOfType<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(theTutorial.TutorialIs == false)
        {
            // 판정체크            
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Touching", true);
            }
            else if (Input.GetMouseButtonUp(0)){
                anim.SetBool("Touching", false);
            }
        }
    }
}
