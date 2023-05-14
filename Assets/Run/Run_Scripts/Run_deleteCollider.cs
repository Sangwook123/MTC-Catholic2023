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
            //노트가 창캐미 뒤쪽에 있는 collision과 만나면 실행
            //제대로 점프하면 블럭은 사라지므로 놓쳤다는 뜻
            if (collision.GetComponent<Run_Note>().GetNoteFlag())
            {
                theTimingManager.MissRecord(); // Miss로 기록
                theEffect.JudgementEffect(4); // Miss 이미지 출력
                theComboManager.ResetCombo(); // 콤보 리셋
                theplayer.ChangeAnim(Run_Player.State.fall);
                Invoke("run", 0.3f);
                soundMiss();
            }
            theTimingManager.boxNoteList.Remove(collision.gameObject); //블럭 리스트에서 제거
            Run_ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            Run_ObjectPool.instance.noteQueue_1.Enqueue(collision.gameObject);
            Run_ObjectPool.instance.noteQueue_2.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false); //블럭 비활성화
        }

    }

    public void soundMiss() // 점프 시 효과음 1회 재생
    {
        sound.PlayOneShot(missSound);
    }

    void run()
    {
        theplayer.ChangeAnim(Run_Player.State.Run_2);
    }
}