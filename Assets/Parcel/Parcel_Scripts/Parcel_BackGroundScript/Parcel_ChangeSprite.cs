using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 구름 재생성하는 코드
// sprite 리스트 안에 있는 요소들 중 랜덤하게 재생성
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
