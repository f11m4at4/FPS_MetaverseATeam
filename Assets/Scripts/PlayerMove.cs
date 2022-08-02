using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� �Է¿� ���� �յ��¿�� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
// CharacterController �� �̿��� �̵���Ű�� �ʹ�.
// �ʿ�Ӽ� : Character Controller
// �߷��� �����Ű�� �ʹ�.
// �ʿ�Ӽ� : �߷°�, �����ӵ�
public class PlayerMove : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;
    // �ʿ�Ӽ� : Character Controller
    CharacterController cc;

    // �ʿ�Ӽ� : �߷°�, �����ӵ�
    public float gravity = -20;
    float yVelocity = 0;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����� �Է¿� ���� �յ��¿�� �̵��ϰ� �ʹ�.
        // 1. ������� �Է¿� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. ������ �ʿ�
        Vector3 dir = new Vector3(h, 0, v);
        // -> ���� �ٶ󺸴� ������ �������� ����ʹ�.
        dir = Camera.main.transform.TransformDirection(dir);
        // v = v0 + at
        // �����ӵ� ���ϱ�
        yVelocity += gravity * Time.deltaTime;
        // ���� �ٴڿ� ����ִٸ�
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            // -> �����ӵ��� 0���� �ϰ� �ʹ�.
            yVelocity = 0;
        }

        dir.y = yVelocity;
        // 3. �̵��ϰ� �ʹ�.
        // P = P0 + vt
        cc.Move(dir * speed * Time.deltaTime);
    }
}
