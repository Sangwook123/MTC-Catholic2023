using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Note : MonoBehaviour
{
    public float noteSpeed = 450; //노트 속도 설정

    UnityEngine.UI.Image noteImage;

    void OnEnable()
    {
        if (noteImage == null)
            noteImage = GetComponent<UnityEngine.UI.Image>();

        noteImage.enabled = true;

    }

    void Update()
    {
        // 시간이 지날 수록 왼쪽으로 이동
        transform.localPosition -= Vector3.right * noteSpeed * Time.deltaTime;
    }

    public void HideNote()
    {
        //노트 이미지 비활성화
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
}