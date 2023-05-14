using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class B_bulb : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float bnoteSpeed = 400;
    //private Image bnoteImage;

    AudioSource smallAudio;

    Bulb_EffectManager theEffect;
    Bulb_ScoreManager theScoreManager;
    Bulb_ComboManager theComboManager;

    Vector3 firstpos;

    public float i_width;
    public int i_height;
    public float b_w;
    public float b_h;
    float a;
    float b;

    b_box b_box;

    // Start is called before the first frame update
    void Start()
    {
        i_width = Screen.width;
        i_height = Screen.height;
        a = 0.1927f;
        b = 0.2685f;
        b_w = a * i_width;
        b_h = b * i_height;

        //bnoteImage = GetComponent<Image>();
        theEffect = FindObjectOfType<Bulb_EffectManager>();
        theScoreManager = FindObjectOfType<Bulb_ScoreManager>();
        theComboManager = FindObjectOfType<Bulb_ComboManager>();
        smallAudio = GetComponent<AudioSource>();
        b_box = FindObjectOfType<b_box>();
    }

    public void Initialized()
    {
        transform.position = Vector3.zero;
        firstpos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right * bnoteSpeed * Time.deltaTime;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        smallAudio.Play();

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        bnoteSpeed = 0;
        transform.position = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        float x1 = b_box.x - (b_w / 2);
        float x2 = b_box.x + (b_w / 2);
        float y1 = b_box.y - (b_h / 2);
        float y2 = b_box.y + (b_h / 2);

        //Blue bulb�� ��ġ�� Blue Perfect ���� �ȿ� ������
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