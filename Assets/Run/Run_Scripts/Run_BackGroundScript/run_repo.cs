using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// ���� ������Ʈ�� ���
public class run_repo : MonoBehaviour
{
    public UnityEvent onMove;

    void LateUpdate()
    {
        if (transform.position.x > -12) //���� x�� �̻� �Ѿ�� �ٽ� ���ʿ��� �����
            return;

        transform.Translate(24, 0, 0, Space.Self);
        onMove.Invoke();
    }
}
