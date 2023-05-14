using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void clickQuit(){
        Debug.Log("quit");
        Application.Quit();
    }
}
