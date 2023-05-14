using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class R_bulb : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float rnoteSpeed = 400;
    private Image rnoteImage;
    AudioSource smallAudio;

    Bulb_EffectManager theEffect;
    Bulb_ScoreManager theScoreManager;
    Bulb_ComboManager theComboManager;

    public int[] judgementRecord = new int[5];
    public float i_width;
    public int i_height;
    public float b_w;
    public float b_h;
    float a;
    float b;

    Vector3 firstpos;

    R_box r_box;
    
    void Start()
    {
        i_width = Screen.width;
        i_height = Screen.height;
        a = 0.1927f;
        b = 0.2685f;
        b_w = a * i_width;
        b_h = b * i_height;

        rnoteImage = GetComponent<Image>();
        theEffect = FindObjectOfType<Bulb_EffectManager>();
        theScoreManager = FindObjectOfType<Bulb_ScoreManager>();
        theComboManager = FindObjectOfType<Bulb_ComboManager>();
        smallAudio = GetComponent<AudioSource>();
        r_box = FindObjectOfType<R_box>();
    }

    public void Initialized()
    {
        transform.position = Vector3.zero;
        firstpos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right * rnoteSpeed * Time.deltaTime;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        smallAudio.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        rnoteSpeed = 0;
        transform.position = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log(transform.position.y);
        float x1 = r_box.x - (b_w / 2);
        float x2 = r_box.x + (b_w / 2);
        float y1 = r_box.y - (b_h / 2);
        float y2 = r_box.y + (b_h / 2);

        /*Debug.Log(i_width);
        Debug.Log(b_w);
        Debug.Log(x1);
        Debug.Log(transform.position.x);*/


        if (transform.position.x >= x1 && transform.position.x <= x2
             && transform.position.y >= y1 && transform.position.y <= y2)
        {
            theEffect.JudgementEffect(0);
            theScoreManager.IncreaseScore(0);

        }
        else if (transform.position.x >= x1 - (0.02f * i_width) && transform.position.x <= x2 + (0.02f * i_width)
            && transform.position.y >= y1 - (0.01f * i_height) && transform.position.y <= y2 + (0.01f * i_height))
        {
            theEffect.JudgementEffect(1);
            theScoreManager.IncreaseScore(1);

        }
        else if (transform.position.x >= x1 - (0.04f * i_width) && transform.position.x <= x2 + (0.04f * i_width)
            && transform.position.y >= y1 - (0.02f * i_height) && transform.position.y <= y2 + (0.02f * i_height))
        {
            theEffect.JudgementEffect(2);
            theScoreManager.IncreaseScore(2);

        }
        else if (transform.position.x >= x1 - (0.06f * i_width) && transform.position.x <= x2 + (0.06f * i_width)
            && transform.position.y >= y1 - (0.04f * i_height) && transform.position.y <= y2 + (0.04f * i_height))
        {
            theEffect.JudgementEffect(3);
            theScoreManager.IncreaseScore(3);

        }
        else
        {
            theComboManager.ResetCombo();
            theEffect.JudgementEffect(4);
            theScoreManager.IncreaseScore(4);
        }
        Destroy(gameObject);
    }
}