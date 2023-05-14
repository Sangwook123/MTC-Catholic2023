using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel_GameResult : MonoBehaviour
{
    Parcel_Scoremanager theScore;
    Parcel_Result theResult;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theResult = FindObjectOfType<Parcel_Result>();
        theScore = FindObjectOfType<Parcel_Scoremanager>();
    }

    public void Update()
    {
        if (theResult.ResultIs == true)
        {
            int t_currentScore = theScore.GetCurrentScore();
            if (t_currentScore < 500) // 1000
            {
                anim.SetBool("isGameClear", false);
            }
            else
            {
                anim.SetBool("isGameClear", true);
                PlayerPrefs.SetInt("parcelisclear", 1);
            }
        }

    }
}
