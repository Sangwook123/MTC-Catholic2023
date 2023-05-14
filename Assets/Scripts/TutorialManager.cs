using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    public bool TutorialIs = true;

    MusicStart theMusic;
    StudentController theStudent;

    // Start is called before the first frame update
    void Start()
    {
        TutorialIs = true;
        theMusic = FindObjectOfType<MusicStart>();
        theStudent = FindObjectOfType<StudentController>();
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
