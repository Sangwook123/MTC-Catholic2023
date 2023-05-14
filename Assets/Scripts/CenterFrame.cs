using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    AudioSource myAudio;
    Animator anim;

    TeacherController theTeacher;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        theTeacher = FindObjectOfType<TeacherController>();
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Note")){
            if(collision.GetComponent<Note>().GetNoteFlag()) {
                theTeacher.play_anim();
            }
        }
    }
}
