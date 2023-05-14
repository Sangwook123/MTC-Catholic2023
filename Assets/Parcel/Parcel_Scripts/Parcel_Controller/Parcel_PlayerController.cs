using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ŭ������ �� Ÿ�̹� üũ�ϴ� �Լ�
public class Parcel_PlayerController : MonoBehaviour
{
    Parcel_TimingManager theTimingManager;
    public bool canPressKey = false;
    public AudioSource mySfx;
    public AudioClip jumpSfx;

    Parcel_Ending theEnding;

    void Start()
    {
        theTimingManager = FindObjectOfType<Parcel_TimingManager>();
        theEnding = FindObjectOfType<Parcel_Ending>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canPressKey)
        {
            if(!theEnding.isGameOver){
                JumpSound();
                theTimingManager.CheckTiming();
            }
            
        }
    }

    public void JumpSound()
    {
        mySfx.PlayOneShot(jumpSfx);
    }
}
