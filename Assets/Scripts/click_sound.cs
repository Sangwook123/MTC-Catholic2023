using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_sound : MonoBehaviour
{

    public AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAudio.Play();
        }
    }
}
