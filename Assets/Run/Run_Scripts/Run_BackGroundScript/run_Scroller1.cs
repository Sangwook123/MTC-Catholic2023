using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ð��� ���� ������ �������� �̵���Ű�� �ڵ�
// ���� reposition ��ũ��Ʈ�� �����ؼ� ����
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
