using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cafe_stop : MonoBehaviour
{
    SchoolLunch_Result theResult;
    SchoolLunch_StartBGM theBGM;

    // Start is called before the first frame update
    void Start()
    {
        theResult = FindObjectOfType<SchoolLunch_Result>();
        theBGM = FindObjectOfType<SchoolLunch_StartBGM>();
    }

    // Update is called once per frame
    public void stopGame(){
        SchoolLunch_GameManager.instance.GameStart();
        theResult.ButtonMainMenu();
        theBGM.gameTime = 0f;
    }
}
