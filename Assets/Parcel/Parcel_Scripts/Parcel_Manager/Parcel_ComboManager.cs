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
        currentCombo += p_num; // �޺� �ϳ��� ����
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        if (currentCombo > 2) // �޺��� 2 �̻��̸� ȭ�鿡 ���
        {
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);
        }
    }

    public int GetCurrentCombo() //���� �޺� ��ȯ���ִ� �ڵ�
    {
        return currentCombo;
    }

    public void ResetCombo() //�޺� �ʱ�ȭ
    {
        currentCombo = 0; //���� �޺� 0���� ����
        txtCombo.text = "0"; // �޺� ����ϴ� text�� 0���� ����
        txtCombo.gameObject.SetActive(false); // �޺� �ؽ�Ʈ ��Ȱ��ȭ
        goComboImage.SetActive(false); // �޺� �̹��� ��Ȱ��ȭ
    }
}
