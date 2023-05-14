using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 구름 오브젝트에 사용
public class run_repo : MonoBehaviour
{
    public UnityEvent onMove;

    void LateUpdate()
    {
        if (transform.position.x > -12) //일정 x값 이상 넘어가면 다시 앞쪽에서 재생성
            return;

        transform.Translate(24, 0, 0, Space.Self);
        onMove.Invoke();
    }
}
