using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_deleteCollider : MonoBehaviour
{
    Run_Player theplayer;
    Run_TimingManager theTimingManager;
    Run_EffectManager theEffect;
    Run_ComboManager theComboManager;
    Run_Note theNote;

    public AudioSource sound;
    public AudioClip missSound;

    void Start()
    {
        theplayer = FindObjectOfType<Run_Player>();
        theTimingManager = FindObjectOfType<Run_TimingManager>();
        theEffect = FindObjectOfType<Run_EffectManager>();
        theComboManager = FindObjectOfType<Run_ComboManager>();
        theNote = FindObjectOfType<Run_Note>();
    }
    void Update()
    {
        if (theplayer.isGround == false)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (theplayer.isGround == true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            //��Ʈ�� âĳ�� ���ʿ� �ִ� collision�� ������ ����
            //����� �����ϸ� ���� ������Ƿ� ���ƴٴ� ��
            if (collision.GetComponent<Run_Note>().GetNoteFlag())
            {
                theTimingManager.MissRecord(); // Miss�� ���
                theEffect.JudgementEffect(4); // Miss �̹��� ���
                theComboManager.ResetCombo(); // �޺� ����
                theplayer.ChangeAnim(Run_Player.State.fall);
                Invoke("run", 0.3f);
                soundMiss();
            }
            theTimingManager.boxNoteList.Remove(collision.gameObject); //�� ����Ʈ���� ����
            Run_ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            Run_ObjectPool.instance.noteQueue_1.Enqueue(collision.gameObject);
            Run_ObjectPool.instance.noteQueue_2.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false); //�� ��Ȱ��ȭ
        }

    }

    public void soundMiss() // ���� �� ȿ���� 1ȸ ���
    {
        sound.PlayOneShot(missSound);
    }

    void run()
    {
        theplayer.ChangeAnim(Run_Player.State.Run_2);
    }
}