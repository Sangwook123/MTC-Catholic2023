using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//���� ������Ʈ�� ���
public class run_repo2 : MonoBehaviour
{
    public UnityEvent onMove;

    void LateUpdate()
    {
        if (transform.position.x > -30) //���� X�� �̻� �Ѿ�� �ٽ� ���ʿ� �����
            return;

        transform.Translate(55, 0, 0, Space.Self);
        onMove.Invoke();
    }
}