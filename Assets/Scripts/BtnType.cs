using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public BTNT currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

    MainVillageBTN MVBTN;
    TitleBTN TBTN;
    FunVillBtn FBTN;

    private void Start(){
        defaultScale = buttonScale.localScale;
    }

    public void OnBtnClick(){
        switch (currentType)
        {
            case BTNT.Start:
                Debug.Log("Start");
                TBTN.BtnMainStart();
                break;

            case BTNT.Fun:
                MVBTN.Funvi();
                break;

            case BTNT.Conv:
                MVBTN.Convi();
                break;

            case BTNT.Health:
                MVBTN.Healvi();
                break;

            case BTNT.Main:
                Debug.Log("Main");
                break;

            case BTNT.Fun1:
                FBTN.FunBaseball();
                break;

            case BTNT.Fun2:
                FBTN.FunBaseball();
                break;

            case BTNT.Conv1:
                Debug.Log("Conv1");
                break;

            case BTNT.Conv2:
                Debug.Log("Conv2");
                break;

            case BTNT.Health1:
                Debug.Log("Health1");
                break;

            case BTNT.Health2:
                Debug.Log("Health2");
                break;

        }
    }

    // 터치 시 버튼 크기 증가
    public void OnPointerDown(PointerEventData eventData){
        buttonScale.localScale = defaultScale * 1.2f;
    }

    // 터치를 떼면 버튼 크기 원상복구
    public void OnPointerUp(PointerEventData eventData){
        buttonScale.localScale = defaultScale;
    }
}
