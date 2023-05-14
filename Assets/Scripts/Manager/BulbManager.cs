using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulbManager : MonoBehaviour
{
    public int bpm = 0;
    public double currentTime = 0d;

    [SerializeField] Transform NoteAppear = null;

    [SerializeField] GameObject y_bulb = null;
    [SerializeField] GameObject r_bulb = null;
    [SerializeField] GameObject b_bulb = null;

    Bulb_TimingManager theTimingManager;
    Bulb_EffectManager theEffect;
    Bulb_ComboManager theComboManager;
    Bulb_Result theResult;
    Bulb_MusicStart theMusic;
    Bulb_TutorialManager theTutorial;
    Bulb_ScoreManager theScoreManager;


    void Start()
    {
        theTimingManager = GetComponent<Bulb_TimingManager>();
        theEffect = FindObjectOfType<Bulb_EffectManager>();
        theComboManager = FindObjectOfType<Bulb_ComboManager>();
        theResult = FindObjectOfType<Bulb_Result>();
        theMusic = FindObjectOfType<Bulb_MusicStart>();
        theTutorial = FindObjectOfType<Bulb_TutorialManager>();
        theScoreManager = FindObjectOfType<Bulb_ScoreManager>();
    }

    void Update()
    {
        if (theTutorial.TutorialIs == false && theResult.ResultIs == false)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= 60d / bpm)
            {
                int random = Random.Range(1, 4);

                if (theMusic.isGameOver)
                {
                    random = 0;
                }
                else
                {
                    if (random == 1)
                    {
                        GameObject R_bulb = Instantiate(r_bulb, NoteAppear.position, Quaternion.identity);
                        R_bulb.transform.SetParent(this.transform);
                        theTimingManager.boxNoteList.Add(R_bulb);
                        R_bulb.transform.localScale = new Vector3(1f, 1f, 0f);
                    }
                    else if (random == 2)
                    {
                        GameObject B_bulb = Instantiate(b_bulb, NoteAppear.position, Quaternion.identity);
                        B_bulb.transform.SetParent(this.transform);
                        theTimingManager.boxNoteList.Add(B_bulb);
                        B_bulb.transform.localScale = new Vector3(1f, 1f, 0f);
                    }
                    else if (random == 3)
                    {
                        GameObject Y_bulb = Instantiate(y_bulb, NoteAppear.position, Quaternion.identity);
                        Y_bulb.transform.SetParent(this.transform);
                        theTimingManager.boxNoteList.Add(Y_bulb);
                        Y_bulb.transform.localScale = new Vector3(1f, 1f, 0f);
                    }

                    currentTime -= 60d / bpm;  // currentTime = 0 ���� �������ָ� �ȵȴ�. 
                }


            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Red_bulb"))
        {
            theComboManager.ResetCombo();
            theEffect.JudgementEffect(4);
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Blue_bulb"))
        {
            theComboManager.ResetCombo();
            theEffect.JudgementEffect(4);
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Yellow_bulb"))
        {
            theEffect.JudgementEffect(0);
            theScoreManager.IncreaseScore(0);
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }


    public void RemoveNote()
    {
        Bulb_GameManager.instance.isStartGame = false;

        for(int i = 0; i < theTimingManager.boxNoteList.Count; i++)
        {
            if(theTimingManager.boxNoteList[i]){
                theTimingManager.boxNoteList[i].SetActive(false);
            }
        }
        theTimingManager.boxNoteList.Clear();
    }
}