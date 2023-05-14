using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간이 지날 때마다 왼쪽으로 이동시키는 코드
// 보통 reposition 스크립트와 접목해서 사용됨
public class run_Scroller1 : MonoBehaviour
{
    public int count;
    public float speedRate;

    void Start()
    {
        count = transform.childCount;
    }


    void Update()
    {
        transform.Translate(speedRate * Time.deltaTime * -1f, 0, 0);
    }
}
