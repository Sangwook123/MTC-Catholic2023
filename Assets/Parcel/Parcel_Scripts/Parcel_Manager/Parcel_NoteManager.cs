using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel_NoteManager : MonoBehaviour
{
    public int bpm = 240;
    public double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;

    Parcel_TimingManager theTimingManager;
    Parcel_ComboManager theComboManager;
    Parcel_EffectManager theEffect;
    Parcel_Tutorial theTutorial;
    Parcel_Result theResult;


    void Start()
    {
        theTimingManager = GetComponent<Parcel_TimingManager>();
        theComboManager = FindObjectOfType<Parcel_ComboManager>();
        theEffect = FindObjectOfType<Parcel_EffectManager>();
        theTutorial = FindObjectOfType<Parcel_Tutorial>();
        theResult = FindObjectOfType<Parcel_Result>();
    }
    // Update is called once per frame

    void Update()
    {
        float time = Random.Range(0, 1);
        IEnumerator Myco()
        {
            yield return new WaitForSeconds(time);
        }

        if (theTutorial.TutorialIs == false && theResult.ResultIs == false)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= 120d / bpm)
            {
                int random = Random.Range(1, 10);

                if (random == 1)
                {
                    GameObject t_note = Parcel_ObjectPool.instance.noteQueue_2.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    theTimingManager.realNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 2)
                {
                    GameObject t_note = Parcel_ObjectPool.instance.noteQueue_1.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true); ;
                    theTimingManager.boxNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 3)
                {
                    GameObject t_note = Parcel_ObjectPool.instance.noteQueue.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 4)
                {
                    GameObject t_note = Parcel_ObjectPool.instance.noteQueue_2.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    theTimingManager.realNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 5)
                {
                    GameObject t_note = Parcel_ObjectPool.instance.noteQueue_2.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    theTimingManager.realNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 6)
                {
                    GameObject t_note = Parcel_ObjectPool.instance.noteQueue_2.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    theTimingManager.realNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 7)
                {
                    GameObject t_note = Parcel_ObjectPool.instance.noteQueue_2.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    theTimingManager.realNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 8)
                {
                    GameObject t_note = Parcel_ObjectPool.instance.noteQueue_2.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);
                    theTimingManager.boxNoteList.Add(t_note);
                    theTimingManager.realNoteList.Add(t_note);
                    t_note.transform.localScale = new Vector3(1f, 1f, 0f);

                }

                if (random == 9)
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
            if (collision.GetComponent<Parcel_Note>().GetNoteFlag())
            {
                theTimingManager.MissRecord();
                theEffect.JudgementEffect(4); 
                theComboManager.ResetCombo();
                theTimingManager.soundmiss();
            }


            theTimingManager.boxNoteList.Remove(collision.gameObject);
            theTimingManager.positionNote.Clear();
            Parcel_ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            Parcel_ObjectPool.instance.noteQueue_1.Enqueue(collision.gameObject);
            Parcel_ObjectPool.instance.noteQueue_2.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false); 
        }

        if (collision.CompareTag("house"))
        {
            theTimingManager.positionNote.Clear();
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Parcel_ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            Parcel_ObjectPool.instance.noteQueue_1.Enqueue(collision.gameObject);
            Parcel_ObjectPool.instance.noteQueue_2.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false); 
        }

    }

    public void RemoveNote()
    {
        Parcel_GameManager.instance.isStartGame = false;

        for (int i = 0; i < theTimingManager.boxNoteList.Count; i++)
        {
            theTimingManager.boxNoteList[i].SetActive(false);
            Parcel_ObjectPool.instance.noteQueue.Enqueue(theTimingManager.boxNoteList[i]);
        }

        theTimingManager.boxNoteList.Clear();
    }
}

