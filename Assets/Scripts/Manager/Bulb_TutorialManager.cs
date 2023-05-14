using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb_TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    [SerializeField] GameObject show_time = null;
    [SerializeField] GameObject stopwatch = null;
    public bool TutorialIs = true;

    Bulb_MusicStart theMusicStart;
    Bulb_GameManager theGame;

    // Start is called before the first frame update
    void Start()
    {
        TutorialIs = true;
        theMusicStart = GetComponent<Bulb_MusicStart>();
        theGame = GetComponent<Bulb_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
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
