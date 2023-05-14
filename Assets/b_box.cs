using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_box : MonoBehaviour
{
    public float x;
    public float y;


    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;

    }
}