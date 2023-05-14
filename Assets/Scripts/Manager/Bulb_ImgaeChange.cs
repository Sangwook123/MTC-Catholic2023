using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulb_ImgaeChange : MonoBehaviour
{

    Bulb_ScoreManager theScore;
    Bulb_Result theResult;

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
        theResult = FindObjectOfType<Bulb_Result>();
        theScore = FindObjectOfType<Bulb_ScoreManager>();

        resultimg = GetComponent<Image>();
        clear = Resources.Load<Sprite>("clear");
        over = Resources.Load<Sprite>("over");
    }

    public void Update()
    {
        if(theResult.ResultIs == true)
        {
            int t_currentScore = theScore.GetCurrentScore();
            if (t_currentScore < 500)
            {
                //anim.SetBool("isGameClear", false);
                resultimg.sprite = over;
            }
            else
            {
                //anim.SetBool("isGameClear", true);
                resultimg.sprite = clear;
                PlayerPrefs.SetInt("bulbisclear", 1);
            }
        }
        
    }
}
