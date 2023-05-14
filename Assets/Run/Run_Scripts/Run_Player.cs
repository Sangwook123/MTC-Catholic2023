using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Player : MonoBehaviour
{
    Run_GameManager theGame;

    public enum State { Stand, Run, Jump, fall, Run_2 }
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;
    public bool isJumpKey;
    public bool presskey;

    public AudioSource mySfx;
    public AudioClip jumpSfx;

    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        theGame = FindObjectOfType<Run_GameManager>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        presskey = false;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGround && presskey) //short jump
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
            JumpSound();
        }
        isJumpKey = Input.GetMouseButton(0);
    }

    // long jump
    void FixedUpdate()
    {
        if (isJumpKey && !isGround)
        {
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
            ChangeAnim(State.Run); //���� ���� �� �ٽ� �޸��� �ִϸ��̼����� ����
            jumpPower = 1;
        }
        isGround = true;

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        ChangeAnim(State.Jump); //���鿡�� �������� �����ϴ� �ִϸ��̼����� ����
        isGround = false;
    }


    public void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }

    public void JumpSound() // ���� �� ȿ���� 1ȸ ���
    {
        mySfx.PlayOneShot(jumpSfx);
    }
}