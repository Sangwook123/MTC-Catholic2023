using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    // Start is called before the first frame update
    public float noteSpeed = 400;

    UnityEngine.UI.Image noteImage;

    void OnEnable() {
        if(noteImage == null) noteImage = GetComponent<UnityEngine.UI.Image>();
        noteImage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 노트가 오른쪽으로 이동
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }

    public void HideNote(){
        noteImage.enabled = false;
    }

    public bool GetNoteFlag(){
        return noteImage.enabled;
    }
}