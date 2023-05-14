using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConOnOff : MonoBehaviour
{
    Image conimg;
    [SerializeField]
    Sprite on;
    [SerializeField]
    Sprite off;
    [SerializeField]
    Sprite con_Parcel_On;
    [SerializeField]
    Sprite con_Bulb_On;

    public void Awake()
    {
        conimg = GetComponent<Image>();
        on = Resources.Load<Sprite>("ConOn");
        off = Resources.Load<Sprite>("ConOff");
        con_Parcel_On = Resources.Load<Sprite>("Con_Parcel_On");
        con_Bulb_On = Resources.Load<Sprite>("Con_Bulb_On");
    }

    public void ConOn()
    {
        conimg.sprite = on;
    }

    public void Con_Parcel_On()
    {
        conimg.sprite = con_Parcel_On;
    }

    public void Con_Bulb_On()
    {
        conimg.sprite = con_Bulb_On;
    }
}
