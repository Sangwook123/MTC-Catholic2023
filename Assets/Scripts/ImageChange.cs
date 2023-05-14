using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageChange : MonoBehaviour
{
    ScoreManager theScore;
    Result theResult;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theResult = FindObjectOfType<Result>();
        theScore = FindObjectOfType<ScoreManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (theResult.ResultIs == true)
        {
            int t_currentScore = theScore.GetCurrentScore();
            if (t_currentScore < 500) // 1000
            {
                anim.SetBool("isGameClear", false);
                //PlayerPrefs.SetInt("baseballisclear", 0);

            }
            else
            {
                anim.SetBool("isGameClear", true);
                PlayerPrefs.SetInt("baseballisclear", 1);
            }
        }
    }
}
