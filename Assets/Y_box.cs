using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_box : MonoBehaviour
{
    public float x;
    public float y;


    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            //Debug.Log("I'm in");

        }

    }
}
