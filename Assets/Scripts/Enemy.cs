using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region ��������
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Damage,
        Die
    };

    EnemyState m_state = EnemyState.Idle;
    #endregion

    #region Idle �Ӽ�
    // �ʿ�Ӽ� : ���ð�, ����ð�
    public float idleDelayTime = 2;
    float currentTime = 0;
    #endregion

    #region Move �Ӽ�
    // �ʿ�Ӽ� : Ÿ��, �̵��ӵ�, CharacterController
    public Transform target;
    public float speed = 5;
    CharacterController cc;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        print("state : " + m_state);
        switch(m_state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Damage:
                Damage();
                break;
            case EnemyState.Die:
                Die();
                break;
        }
    }

    // �����ð��� ������ ���¸� �̵����� ��ȯ�ϰ� �ʹ�.

    private void Idle()
    {
        // �����ð��� ������ ���¸� �̵����� ��ȯ�ϰ� �ʹ�.
        // 1. �ð��� �귶���ϱ�
        currentTime += Time.deltaTime;
        // 2. �ð��� �����ϱ�
        if (currentTime > idleDelayTime)
        {
            // 3. ���¸� �̵����� ��ȯ
            m_state = EnemyState.Move;
            currentTime = 0;
        }
    }

    // Ÿ�������� �̵��ϰ� �ʹ�.

    private void Move()
    {
        // Ÿ�������� �̵��ϰ� �ʹ�.
        // 1. �������ʿ�(target - me)
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        // 2. �̵��ϰ� �ʹ�.
        cc.SimpleMove(dir * speed);
    }

    private void Attack()
    {
        throw new NotImplementedException();
    }

    private void Damage()
    {
        throw new NotImplementedException();
    }

    private void Die()
    {
        throw new NotImplementedException();
    }
}
