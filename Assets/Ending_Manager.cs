using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Ending_Manager : MonoBehaviour
{
    public VideoPlayer vdo;
    [SerializeField] GameObject goVideoUI = null;
    [SerializeField] GameObject goTitleUI = null;

    public void Start(){
        
    }

    public void Update(){
        if(vdo.time > 38){
            skip();
        }
    }

    public void startEnding(){
        goVideoUI.SetActive(true);
        goTitleUI.SetActive(false);
        vdo.Play();
    }

    public void skip()
    {
        vdo.Stop();
        goTitleUI.SetActive(true);
        goVideoUI.SetActive(false);
    }
}
