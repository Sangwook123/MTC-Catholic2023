using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulb_CJManager : MonoBehaviour
{
    //Animator anim;
    Bulb_EffectManager theEffect;

    Image cjimg;
    [SerializeField]
    Sprite happy;
    [SerializeField]
    Sprite sad;

    public AudioSource beebSound;

    // Start is called before the first frame update
    void Start()
    {
        theEffect = FindObjectOfType<Bulb_EffectManager>();
        InvokeRepeating("Change", 0.1f, 0.1f);

        cjimg = GetComponent<Image>();
        happy = Resources.Load<Sprite>("happy");
        sad = Resources.Load<Sprite>("sad");
        beebSound = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    public void Change()
    {
        if (theEffect.isMiss)
        {
            cjimg.sprite = sad;
            
        }
        else
        {
            cjimg.sprite = happy;
        }

    }
}
