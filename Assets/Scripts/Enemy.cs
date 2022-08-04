using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 상태정의
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

    #region Idle 속성
    // 필요속성 : 대기시간, 경과시간
    public float idleDelayTime = 2;
    float currentTime = 0;
    #endregion

    #region Move 속성
    // 필요속성 : 타겟, 이동속도, CharacterController
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

    // 일정시간이 지나면 상태를 이동으로 전환하고 싶다.

    private void Idle()
    {
        // 일정시간이 지나면 상태를 이동으로 전환하고 싶다.
        // 1. 시간이 흘렀으니까
        currentTime += Time.deltaTime;
        // 2. 시간이 됐으니까
        if (currentTime > idleDelayTime)
        {
            // 3. 상태를 이동으로 전환
            m_state = EnemyState.Move;
            currentTime = 0;
        }
    }

    // 타겟쪽으로 이동하고 싶다.

    private void Move()
    {
        // 타겟쪽으로 이동하고 싶다.
        // 1. 방향이필요(target - me)
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        // 2. 이동하고 싶다.
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
