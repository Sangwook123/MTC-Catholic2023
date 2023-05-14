using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ϴ� �ڵ�
// sprite ����Ʈ �ȿ� �ִ� ��ҵ� �� �����ϰ� �����
public class Parcel_ChangeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer spriter;
    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        Change();
    }

    
    public void Change()
    {
        int ran = Random.Range(0, sprites.Length);
        spriter.sprite = sprites[ran];
    }
}
