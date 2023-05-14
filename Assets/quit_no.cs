using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit_no : MonoBehaviour
{
    [SerializeField] GameObject goquitUI = null;

    public void clickNo(){
        Debug.Log("no");
        goquitUI.SetActive(false);
    }

    public void clickyes(){
        Debug.Log("yes");
        Application.Quit();
    }

    public void clickQuit(){
        Debug.Log("quit");
        goquitUI.SetActive(true);
    }
}
