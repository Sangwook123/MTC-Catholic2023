using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel_Tutorial : MonoBehaviour
{
    [SerializeField] GameObject goTuto1 = null;
    [SerializeField] GameObject goTuto2 = null;
    public bool TutorialIs = true;
    bool click = false;
    Parcel_Ending theEnding;


    // Start is called before the first frame update
    void Start()
    {
        TutorialIs = true;
        click = false;
        theEnding = FindObjectOfType<Parcel_Ending>();
    }

    void Update(){
        if(TutorialIs) ShowTutorial();
    }

    public void ShowTutorial()
    {
        goTuto1.SetActive(true);
        TutorialIs = true;
        if (Input.GetMouseButtonDown(0))
        {
            goTuto1.SetActive(false);
            ShowTutorial2();
            click = true;
        }
    }

    public void ShowTutorial2()
    {
        goTuto2.SetActive(true);
        if(click){
            if (Input.GetMouseButtonDown(0))
            {
                goTuto2.SetActive(false);
                TutorialIs = false;
            }
        }    
    }
}
