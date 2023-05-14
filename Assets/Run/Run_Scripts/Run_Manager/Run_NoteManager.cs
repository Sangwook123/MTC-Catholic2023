using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_NoteManager : MonoBehaviour
{
    public int bpm = 0;
    public double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;

    Run_TimingManager theTimingManager;
    Run_ComboManager theComboManager;
    Run_EffectManager theEffect;
    Run_Tutorial theTutorial;
    Run_Result theResult;
    Run_Player thePlayer;

    void Start()
    {
        theTimingManager = GetComponent<Run_TimingManager>();
        theComboManager = FindObjectOfType<Run_ComboManager>();
        theEffect = FindObjectOfType<Run_EffectManager>();
        theTutorial = FindObjectOfType<Run_Tutorial>();
        theResult = FindObjectOfType<Run_Result>();
        thePlayer = FindObjectOfType<Run_Player>();
    }
    // Update is called once per frame

    void Update()
    {
        float time = Random.Range(0, 2);
        IEnumerator Myco()
        {
            yield return new WaitForSeconds(time);
        }

        if (theTutorial.TutorialIs == false && theResult.ResultIs == false)
        {
            currentTime += Time.deltaTime;
            thePlayer.presskey = true;

            if (currentTime >= 120d / bpm)
            {
                int random = Random.Range(1, 6);

                if (random == 1)
                {
                    GameObject t_note = Run_ObjectPool.instance.noteQueue.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 2)
                {
                    GameObject t_note = Run_ObjectPool.instance.noteQueue_1.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true); ;
                    theTimingManager.boxNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 3)
                {
                    GameObject t_note = Run_ObjectPool.instance.noteQueue_2.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 4)
                {
                    GameObject t_note = Run_ObjectPool.instance.noteQueue_1.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 5)
                {
                    StartCoroutine(Myco());

                }

                currentTime -= 120d / bpm;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Run_Note>().GetNoteFlag())
            {
                theTimingManager.MissRecord();
                theEffect.JudgementEffect(4);
                theComboManager.ResetCombo();
            }

            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Run_ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            Run_ObjectPool.instance.noteQueue_1.Enqueue(collision.gameObject);
            Run_ObjectPool.instance.noteQueue_2.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
            
        }
    }

    public void RemoveNote()
    {
        Run_GameManager.instance.isStartGame = false;

        for (int i = 0; i < theTimingManager.boxNoteList.Count; i++)
        {
            theTimingManager.boxNoteList[i].SetActive(false);
            Run_ObjectPool.instance.noteQueue.Enqueue(theTimingManager.boxNoteList[i]);
        }

        theTimingManager.boxNoteList.Clear();
    }
}