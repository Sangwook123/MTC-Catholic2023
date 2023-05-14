using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    public VideoPlayer vdo;
    [SerializeField] GameObject goIntroUI = null;
    [SerializeField] GameObject goVideoUI = null;
    [SerializeField] GameObject goTitleUI = null;

    public void videoStart(){
        goIntroUI.SetActive(false);
        goVideoUI.SetActive(true);
        vdo.Play();
    }

    public void Update(){
        if(vdo.time > 53){
            skip();
        }
    }

    public void skip()
    {
        vdo.Stop();
        goTitleUI.SetActive(true);
        goVideoUI.SetActive(false);
    }
}
