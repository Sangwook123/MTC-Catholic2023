using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_PlayerController : MonoBehaviour
{
    Run_TimingManager theTimingManager;
    Run_Player theplayer;

    void Start()
    {
        theTimingManager = FindObjectOfType<Run_TimingManager>();
        theplayer = FindObjectOfType<Run_Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && theplayer.presskey)
        {
            theTimingManager.CheckTiming();
        }
    }
}