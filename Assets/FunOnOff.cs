using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunOnOff : MonoBehaviour
{
    //Animator anim;
    Image funimg;
    [SerializeField]
    Sprite on;
    [SerializeField]
    Sprite off;
    [SerializeField]
    Sprite fun_Lego_On;
    [SerializeField]
    Sprite fun_Baseball_On;

    public void Awake()
    {
        funimg = GetComponent<Image>();
        on = Resources.Load<Sprite>("FunOn");
        off = Resources.Load<Sprite>("FunOff");
        fun_Lego_On = Resources.Load<Sprite>("Fun_Lego_On");
        fun_Baseball_On = Resources.Load<Sprite>("Fun_Baseball_On");
    }
  
    public void FunOn()
    {
        funimg.sprite = on;
    }

    public void Fun_Lego_On()
    {
        funimg.sprite = fun_Lego_On;
    }

    public void Fun_Baseball_On()
    {
        funimg.sprite = fun_Baseball_On;
    }
}
