using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0; // 1분당 비트 수 
    double currentTime = 0d; // 노트 생성 시간 계산 변수
    double gametime = 0d;
    public Animator ani;

    [SerializeField] Transform tfNoteAppear = null; // 노트가 생성될 위치 변수

    public System.Random ran = new System.Random();

    TimingManager theTimingManager;
    EffectManager theEffectManager;
    ComboManager theComboManager;
    TeacherController theTeacher;
    Result theResult;
    MusicStart theMusic;
    TutorialManager theTutorial;
    base_GameManager theBaseGame;



    void Start(){
        theTimingManager = GetComponent<TimingManager>();
        theTutorial = FindObjectOfType<TutorialManager>();
        theEffectManager = FindObjectOfType<EffectManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theTeacher = FindObjectOfType<TeacherController>();
        theResult = FindObjectOfType<Result>();
        theMusic = FindObjectOfType<MusicStart>();
        theBaseGame = FindObjectOfType<base_GameManager>();

        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theTutorial.TutorialIs == false && theResult.ResultIs == false){
            if(!theMusic.isGameOver){
                gametime += Time.deltaTime;
                currentTime += Time.deltaTime; // 1초에 1씩 증가
        
                double random_number = ran.Next(60, 120);
                random_number *= 1d;
                
                if(currentTime >= 100d / bpm) {
                    //StartCoroutine(theTeacher.on_Anim());

                    GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
                    t_note.transform.position = tfNoteAppear.position;
                    t_note.SetActive(true);

                    theTimingManager.boxNoteList.Add(t_note);
                    currentTime -= random_number / bpm;
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Note")){
            if(collision.GetComponent<Note>().GetNoteFlag()) {
                theTimingManager.MissRecord();
            }

            theTimingManager.boxNoteList.Remove(collision.gameObject);
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
    
    public void RemoveNote()
    {
        theBaseGame.isStartGame = false;

        for(int i = 0; i < theTimingManager.boxNoteList.Count; i++){
            theTimingManager.boxNoteList[i].SetActive(false);
            ObjectPool.instance.noteQueue.Enqueue(theTimingManager.boxNoteList[i]);
        }
        theTimingManager.boxNoteList.Clear();
    }
}