using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lego_TeacherController : MonoBehaviour
{
    Animator anim;
    public int random;
    public bool isWatching;

    Lego_StudentController theStudent;
    Lego_EffectMananger theEffect;
    Lego_ScoreMananger theScore;
    Lego_ComboManager theCombo;
    Lego_MusicStart theMusicStart;
    Lego_TutorialManager theTutorial;
    Lego_Result theResult;


    //float timeSpan; //��� �ð�

    int temp;
    int LastRandom;
    float starttime;
    //float clicktime;
    float betweentime;


    // Start is called before the first frame update
    void Start()
    {
        theStudent = FindObjectOfType<Lego_StudentController>();
        theEffect = FindObjectOfType<Lego_EffectMananger>();
        theScore = FindObjectOfType<Lego_ScoreMananger>();
        theCombo = FindObjectOfType<Lego_ComboManager>();
        theMusicStart = FindObjectOfType<Lego_MusicStart>();
        theTutorial = FindObjectOfType<Lego_TutorialManager>();
        theResult = FindObjectOfType<Lego_Result>();


        anim = GetComponent<Animator>();

        //Change �Լ��� 3�� �Ŀ�, 1�ʸ��� ����
        InvokeRepeating("Change", 1, 1.0f);

        //timeSpan = 0.0f;
    }

    public void Initialized()
    {
        //timeSpan = 0.0f;

    }


    public void Change()
    {
        //Debug.Log(theTutorial.TutorialIs);
        //Ʃ�丮�� X && ���â X
        if (theTutorial.TutorialIs == false && theResult.ResultIs == false)
        {
            if (theMusicStart.isGameOver)
            {
                random = 4;
            }
            else
            {
                theMusicStart.musicStart = true;

                //0���� 2���� ������ ����
                random = Random.Range(0, 3);

                //�������� 0�̸�
                if (random == 0)
                {
                    temp = random;
                    LastRandom = temp;

                    //�������� �л��� ���Ѻ��� �ִϸ��̼� ����
                    anim.SetBool("Watching", true);
                    isWatching = true;
                    starttime = Time.time;


                    if (theStudent.isTouching && LastRandom == 0)
                    {
                        StartCoroutine(Perfect());

                    }
                    else
                    {
                        StartCoroutine(CheckClick1());
                    }

                }


                //�������� 1,2�̸�
                else
                {
                    //�������� ĥ�� ���� �ִϸ��̼� ����
                    anim.SetBool("Watching", false);
                    isWatching = false;

                    StartCoroutine(CheckClick2());

                }
            }
        }
    }


    IEnumerator CheckClick1()
    {
        //1초 후에 밑에 실행
        yield return new WaitForSeconds(1f);

        //Debug.Log("clicktime = " + theStudent.clicktime);
        //Debug.Log("starttime = " + starttime);


        betweentime = theStudent.clicktime - starttime;
        //Debug.Log("betweentime = " + betweentime);

        if (betweentime < 0.4f && theStudent.isTouching)
        {
            //Debug.Log(betweentime);
            theEffect.JudgementEffect(0);
            theScore.IncreaseScore(0);
            //Debug.Log("perfect");
            starttime = 0.0f;

        }
        else if (betweentime < 0.5f && theStudent.isTouching)
        {
            //Debug.Log(betweentime);
            theEffect.JudgementEffect(1);
            theScore.IncreaseScore(1);
            //Debug.Log("cool");
            starttime = 0.0f;
        }
        else if (betweentime < 0.6f && theStudent.isTouching)
        {
            //Debug.Log(betweentime);
            theEffect.JudgementEffect(2);
            theScore.IncreaseScore(2);
            //Debug.Log("good");
            starttime = 0.0f;
        }
        else if (betweentime < 1.1f && theStudent.isTouching)
        {
            //Debug.Log(betweentime);
            theEffect.JudgementEffect(3);
            theScore.IncreaseScore(3);
            //Debug.Log("bad");
            starttime = 0.0f;
        }
        else if (!theStudent.isTouching)
        {
            //Debug.Log(betweentime);
            theEffect.JudgementEffect(4);
            theScore.IncreaseScore(4);
            theCombo.ResetCombo();
            //Debug.Log("miss");
            starttime = 0.0f;
        }



        theStudent.clicktime = 0.0f;

    }

    IEnumerator CheckClick2()
    {
        //�������� ĥ���� �� ��
        yield return new WaitForSeconds(1f);

        //�л��� å�� �а� ������
        if (theStudent.isTouching)
        {
            theEffect.JudgementEffect(4);
            theScore.IncreaseScore(4);
            theCombo.ResetCombo();
        }

    }

    IEnumerator Perfect()
    {
        yield return new WaitForSeconds(1f);
        theEffect.JudgementEffect(0);
        theScore.IncreaseScore(0);
        //Debug.Log("perfect");
        starttime = 0.0f;
    }

    IEnumerator Miss()
    {
        yield return new WaitForSeconds(1f);
        theEffect.JudgementEffect(4);
        theScore.IncreaseScore(4);
        theCombo.ResetCombo();
        //timeSpan = 0.0f;
    }
}