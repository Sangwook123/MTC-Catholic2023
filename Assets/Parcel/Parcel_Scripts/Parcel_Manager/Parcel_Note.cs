using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel_Note : MonoBehaviour
{
    public float noteSpeed = 700; //��Ʈ �ӵ� ����

    UnityEngine.UI.Image noteImage;

    void OnEnable()
    {
        if (noteImage == null)
            noteImage = GetComponent<UnityEngine.UI.Image>();

        noteImage.enabled = true;

    }

    void Update()
    {
        // �ð��� ���� ���� �������� �̵�
        transform.localPosition -= Vector3.right * noteSpeed * Time.deltaTime;
    }

    public void HideNote()
    {
        //��Ʈ �̹��� ��Ȱ��ȭ
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
}
