using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Object Pool 코드 (케이디 리듬게임 '오브젝트 풀' 코드 작성)
public class ObjectInfo
{
    public GameObject goPrefab;
    public int count;
    public Transform tfPoolParent;
}

public class Parcel_ObjectPool : MonoBehaviour
{
    public static Parcel_ObjectPool instance;

    [SerializeField] ObjectInfo[] objectInfo = null;

    public Queue<GameObject> noteQueue = new Queue<GameObject>();
    public Queue<GameObject> noteQueue_1 = new Queue<GameObject>();
    public Queue<GameObject> noteQueue_2 = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        noteQueue = InsertQueue(objectInfo[0]);
        noteQueue_1 = InsertQueue(objectInfo[1]);
        noteQueue_2 = InsertQueue(objectInfo[2]);
    }

    // Update is called once per frame
    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();
        for(int i = 0; i < p_objectInfo.count; i++)
        {
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity);
            t_clone.SetActive(false);
            if (p_objectInfo.tfPoolParent != null)
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            else
                t_clone.transform.SetParent(this.transform);

            t_queue.Enqueue(t_clone);
        }
        return t_queue;
    }
}
