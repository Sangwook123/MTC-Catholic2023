using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lego_ImageChange : MonoBehaviour
{
    Lego_ScoreMananger theScore;
    Lego_Result theResult;

    //Animator anim;

    Image resultimg;
    [SerializeField]
    Sprite clear;
    [SerializeField]
    Sprite over;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        theResult = FindObjectOfType<Lego_Result>();
        theScore = FindObjectOfType<Lego_ScoreMananger>();
        resultimg = GetComponent<Image>();
        clear = Resources.Load<Sprite>("clear");
        over = Resources.Load<Sprite>("over");
    }

    // Update is called once per frame
    void Update()
    {
        if (theResult.ResultIs == true)
        {
            int t_currentScore = theScore.GetCurrentScore();
            if (t_currentScore < 500)
            {
                //anim.SetBool("isGameClear", false);
                //PlayerPrefs.SetInt("legoisclear", 0);
                resultimg.sprite = over;
            }
            else
            {
                //anim.SetBool("isGameClear", true);
                resultimg.sprite = clear;
                PlayerPrefs.SetInt("legoisclear", 1);
            }
        }
    }
}
