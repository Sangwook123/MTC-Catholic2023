using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_GameResult : MonoBehaviour
{
    Run_Scoremanager theScore;
    Run_Result theResult;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theResult = FindObjectOfType<Run_Result>();
        theScore = FindObjectOfType<Run_Scoremanager>();
    }

    public void Update()
    {
        if (theResult.ResultIs == true)
        {
            int t_currentScore = theScore.GetCurrentScore();
            if (t_currentScore < 500)
            {
                anim.SetBool("isGameClear", false);
            }
            else
            {
                anim.SetBool("isGameClear", true);
                PlayerPrefs.SetInt("runisclear", 1);
            }
        }

    }
}
