using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel_ComboManager : MonoBehaviour
{
    [SerializeField] GameObject goComboImage = null;
    [SerializeField] UnityEngine.UI.Text txtCombo = null;

    public int currentCombo = 0;

    void Start()
    {
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }

    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num; // 콤보 하나씩 증가
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        if (currentCombo > 2) // 콤보가 2 이상이면 화면에 출력
        {
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);
        }
    }

    public int GetCurrentCombo() //현재 콤보 반환해주는 코드
    {
        return currentCombo;
    }

    public void ResetCombo() //콤보 초기화
    {
        currentCombo = 0; //현재 콤보 0으로 설정
        txtCombo.text = "0"; // 콤보 출력하는 text도 0으로 설정
        txtCombo.gameObject.SetActive(false); // 콤보 텍스트 비활성화
        goComboImage.SetActive(false); // 콤보 이미지 비활성화
    }
}
