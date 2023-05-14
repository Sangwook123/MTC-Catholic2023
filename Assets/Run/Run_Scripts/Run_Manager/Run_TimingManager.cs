using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_TimingManager : MonoBehaviour
{

    public List<GameObject> boxNoteList = new List<GameObject>();

    public int[] judgementRecord = new int[5];

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    Run_EffectManager theEffect;
    Run_Scoremanager theScoreManager;
    Run_ComboManager theComboManager;

    void Start()
    {
        theEffect = FindObjectOfType<Run_EffectManager>();
        theScoreManager = FindObjectOfType<Run_Scoremanager>();
        theComboManager = FindObjectOfType<Run_ComboManager>();

        //timing box
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public void destoryBlock()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            boxNoteList[i].GetComponent<Run_Note>().HideNote();
            boxNoteList.RemoveAt(i);
            return;
        }
    }
    // Update is called once per frame
    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    Invoke("destoryBlock", 0.6f); //0.6�� �� destoryBlock �Լ� ȣ��
                    theEffect.JudgementEffect(x); // Effect ���
                    judgementRecord[x]++; // Ÿ�̹� ���

                    theScoreManager.IncreaseScore(x); // ���� ����
                    return;
                }
            }
        }

        theComboManager.ResetCombo();
        theEffect.JudgementEffect(timingBoxs.Length); 
        MissRecord();
    }

    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }

    public void MissRecord()
    {
        judgementRecord[4]++;
    }

    public void Initialized()
    {
        judgementRecord[0] = 0;
        judgementRecord[1] = 0;
        judgementRecord[2] = 0;
        judgementRecord[3] = 0;
        judgementRecord[4] = 0;
    }
}
