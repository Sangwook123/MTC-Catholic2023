using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    // 생성된 노트를 담는 list => 판정 범위에 있는지 모든 노트를 비교함
    public List<GameObject> boxNoteList = new List<GameObject>();
    // 판정 범위 (perfect, cool, good, miss)
    [SerializeField] RectTransform[] timingRect = null;
    // 판정 범위의 최소값(x), 최대값(y)
    Vector2[] timingBoxs = null;

    public bool isover = true;
    int[] judgementRecord = new int[5];

    EffectManager theEffect;
    ScoreManager theScoreManager;
    ComboManager theComboManager;
    MusicStart theMusic;
    StudentController theStudent;
    TeacherController theTeacher;

    // Start is called before the first frame update
    void Start()
    {
        
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theMusic = FindObjectOfType<MusicStart>();
        theStudent = FindObjectOfType<StudentController>();
        theTeacher = FindObjectOfType<TeacherController>();
        
        // 타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length];

        timingBoxs[0].Set(-50, -20);
        timingBoxs[1].Set(-20, 20);
        timingBoxs[2].Set(20, 60);
        timingBoxs[3].Set(60, 140);
    }

    public void CheckTiming(){
        if((theMusic.isGameOver == false) && (theMusic.musicStart == true)){
            for (int i = 0; i < boxNoteList.Count; i++){
                float t_notePosX = boxNoteList[i].transform.localPosition.x;

                for (int x = 0; x < timingBoxs.Length; x++)
                {
                    if(timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                    {
                        // 노트제거
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        theEffect.JudgementEffect(x);

                        // 점수 증가
                        theScoreManager.IncreaseScore(x);
                        judgementRecord[x]++; // 판정 기록
                        Debug.Log("hit" + t_notePosX);
                        return;
                    }
                }
            }
            Debug.Log("miss");
            MissRecord();
        }
    }
    
    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }

    public void MissRecord()
    {
        theComboManager.ResetCombo();
        theEffect.JudgementEffect(4);
        judgementRecord[4]++;
    }

    public void Initialized()
    {
        for(int i = 0; i < 5; i++){
            judgementRecord[i] = 0;
        }
    }
    
}
