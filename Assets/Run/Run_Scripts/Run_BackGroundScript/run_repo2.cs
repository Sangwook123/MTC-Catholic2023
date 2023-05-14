using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//레인 오브젝트에 사용
public class run_repo2 : MonoBehaviour
{
    public UnityEvent onMove;

    void LateUpdate()
    {
        if (transform.position.x > -30) //일정 X값 이상 넘어가면 다시 앞쪽에 재생성
            return;

        transform.Translate(55, 0, 0, Space.Self);
        onMove.Invoke();
    }
}