using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� �Է¿� ���� �յ��¿�� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
// CharacterController �� �̿��� �̵���Ű�� �ʹ�.
// �ʿ�Ӽ� : Character Controller
// �߷��� �����Ű�� �ʹ�.
// �ʿ�Ӽ� : �߷°�, �����ӵ�
// ����ڰ� ������ư�� ������ �����ϰ� �ʹ�.
// �ʿ�Ӽ� : �����Ŀ�
public class PlayerMove : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;
    // �ʿ�Ӽ� : Character Controller
    CharacterController cc;

    // �ʿ�Ӽ� : �߷°�, �����ӵ�
    public float gravity = -20;
    float yVelocity = 0;
    // �ʿ�Ӽ� : �����Ŀ�
    public float jumpPower = 5;

    // ���������� ����
    bool isJumping = false;
    int isJumpingcount = 0;
    public int maxJumpCount = 2;

    Animator anim;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����� �Է¿� ���� �յ��¿�� �̵��ϰ� �ʹ�.
        // 1. ������� �Է¿� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        // 2. ������ �ʿ�
        Vector3 dir = new Vector3(h, 0, v);
        // -> ���� �ٶ󺸴� ������ �������� ����ʹ�.
        dir = Camera.main.transform.TransformDirection(dir);
        // v = v0 + at
        // �����ӵ� ���ϱ�
        yVelocity += gravity * Time.deltaTime;

        // �ٴڰ��� �Ÿ��� 0.05 ���� ũ�� ���߿� �ִ�.
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitInfo;
        int layer = 1 << gameObject.layer;
        if(Physics.Raycast(ray, out hitInfo, 0.1f, ~layer) == false)
        {
            // ����
            anim.SetBool("IsInAir", true);

        }

        // ���� �ٴڿ� ����ִٸ�
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            // -> �����ӵ��� 0���� �ϰ� �ʹ�.
            yVelocity = 0;
            //isJumping = false;
            isJumpingcount = 0;

            anim.SetBool("IsInAir", false);

        }

        // ������ ���ϰ� ���� �� �׸���
        // ����ڰ� ������ư�� ������ �����ϰ� �ʹ�.
        if (Input.GetButtonDown("Jump") && isJumpingcount < maxJumpCount)
        {
            // -> �����ӵ��� �����ϰ� �ʹ�.
            yVelocity = jumpPower;
            //isJumping = true;
            isJumpingcount++;
            anim.SetBool("IsInAir", true);
        }

        dir.y = yVelocity;
        // 3. �̵��ϰ� �ʹ�.
        // P = P0 + vt
        cc.Move(dir * speed * Time.deltaTime);
    }
}
