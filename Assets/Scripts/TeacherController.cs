using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TeacherController : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
    }

    public IEnumerator on_Anim(){
        Debug.Log("on");
        yield return new WaitForSeconds(2.0f);
        //anim.SetTrigger("Cheer");

        //StartCoroutine(off_Anim());
    }

    public IEnumerator off_Anim(){
        yield return new WaitForSeconds(0.003f);
        Debug.Log("off");
    }

/*
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Note")){
            if(collision.GetComponent<Note>().GetNoteFlag()) {
                anim.SetTrigger("Cheer");
            }
        }
    }*/

    public void play_anim(){
        anim.SetTrigger("Cheer");
    }
}