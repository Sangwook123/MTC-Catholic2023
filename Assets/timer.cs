using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    // 남은 시간
    [SerializeField] Text remaining_time = null;
    [SerializeField] GameObject show_time = null;

    Run_Ending theRunEnd;
    public float remain_Time;

    private void Start()
    {
        theRunEnd = FindObjectOfType<Run_Ending>();
    }

    void Start_Time()
    {
        remain_Time = 45 - theRunEnd.gameTime;

        // 남은 시간
        remaining_time.text = string.Format("{0:N2}", remain_Time);// 소수점 두자리까지
    }

    public void Set_True(){
        Start_Time();
        show_time.SetActive(true);
    }

    public void Set_False(){
        show_time.SetActive(false);
    }
}
