using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel_TimingManager : MonoBehaviour
{

    public List<GameObject> boxNoteList = new List<GameObject>();
    public List<GameObject> realNoteList = new List<GameObject>();

    public List<float> positionNote = new List<float>();

    public int[] judgementRecord = new int[5];
    public float noteposition;

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    Parcel_EffectManager theEffect;
    Parcel_Scoremanager theScoreManager;
    Parcel_ComboManager theComboManager;

    public AudioSource parcel_miss;
    public AudioClip parcel_missAudio;

    void Start()
    {
        theEffect = FindObjectOfType<Parcel_EffectManager>();
        theScoreManager = FindObjectOfType<Parcel_Scoremanager>();
        theComboManager = FindObjectOfType<Parcel_ComboManager>();

        //timing box ����
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }


    void checkNote()
    {
        if (realNoteList.Count > 0)
        {
            float x = GameObject.FindGameObjectWithTag("Note").transform.localPosition.x;
            noteposition = x;
            positionNote.Add(noteposition);
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;
            if (GameObject.FindWithTag("Note"))
            {
                checkNote();
            }
            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y && positionNote.Count > 0)
                {
                    if (timingBoxs[x].x <= positionNote[i] && positionNote[i] <= timingBoxs[x].y)
                    {
                        boxNoteList[i].GetComponent<Parcel_Note>().HideNote();
                        boxNoteList.RemoveAt(i);
                        theEffect.JudgementEffect(x); // Effect ���
                        judgementRecord[x]++; // Ÿ�̹� ���
                        theScoreManager.IncreaseScore(x); // ���� ����
                        positionNote.RemoveAt(0);
                        return;
                    }
                }
            }
        }

        //���� Ÿ�̹��� ���ƴٸ�
        if (positionNote.Count > 0)
        {
            positionNote.RemoveAt(0);
        }
        theComboManager.ResetCombo(); //�޺� �ʱ�ȭ
        theEffect.JudgementEffect(timingBoxs.Length); //Miss ����Ʈ ���
        MissRecord(); //Miss�� ���
        soundmiss();
    }

    public int[] GetJudgementRecord() //���� ��� ��ȯ
    {
        return judgementRecord;
    }

    public void MissRecord() //Miss�� ���
    {
        judgementRecord[4]++;
    }

    public void Initialized()
    {
        //���� �ʱ�ȭ
        judgementRecord[0] = 0;
        judgementRecord[1] = 0;
        judgementRecord[2] = 0;
        judgementRecord[3] = 0;
        judgementRecord[4] = 0;
    }

    public void soundmiss()
    {
        parcel_miss.PlayOneShot(parcel_missAudio);
    }
}