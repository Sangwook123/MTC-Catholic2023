using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lego_TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    public bool TutorialIs = true;
    Lego_MusicStart theMusic;

    // Start is called before the first frame update
    void Start()
    {
        TutorialIs = true;
        theMusic = FindObjectOfType<Lego_MusicStart>();
    }

    public void Initialized()
    {
        TutorialIs = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(TutorialIs == true)
            {
                theMusic.musicStart = true;
                theMusic.myAudio.Play();
            }
            goUI.SetActive(false);
            TutorialIs = false;
        }
    }

    public void ShowTutorial()
    {
        goUI.SetActive(true);
        TutorialIs = true;
    }
}
