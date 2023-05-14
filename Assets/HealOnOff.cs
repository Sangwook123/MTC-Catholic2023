using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealOnOff : MonoBehaviour
{
    Image healimg;
    [SerializeField]
    Sprite on;
    [SerializeField]
    Sprite off;
    [SerializeField]
    Sprite heal_Cafeteria_On;
    [SerializeField]
    Sprite heal_Run_On;

    public void Awake()
    {
        healimg = GetComponent<Image>();
        on = Resources.Load<Sprite>("HealOn");
        off = Resources.Load<Sprite>("HealOff");
        heal_Cafeteria_On = Resources.Load<Sprite>("Heal_Cafeteria_On");
        heal_Run_On = Resources.Load<Sprite>("Heal_Run_On");
    }

    public void HealOn()
    {
        healimg.sprite = on;
    }

    public void Heal_Cafeteria_On()
    {
        healimg.sprite = heal_Cafeteria_On;
    }

    public void Heal_Run_On()
    {
        healimg.sprite = heal_Run_On;
    }
}
