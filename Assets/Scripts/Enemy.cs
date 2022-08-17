using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Idle ���� Move �� ��ȯ�Ǵ� �ִϸ��̼� ó���� �ϰ� �ʹ�.
// �ʿ�Ӽ� : Animator
// Ÿ������ �̵��� �� ���� ���������� ��Ʈ�� �ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��� �� �ִ� ����
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
    // �ʿ�Ӽ� : �̵��� �� �ִ� ����
    public float moveToTargetRange = 5;
    #endregion

    // �ʿ�Ӽ� : Animator
    Animator anim;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        print("state : " + m_state);
        switch (m_state)
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
                //Damage();
                break;
            case EnemyState.Die:
               // Die();
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
            // �ִϸ��̼��� ���µ� �̵����� ��ȯ
            anim.SetTrigger("Move");

            agent.enabled = true;
        }
    }

    // Ÿ�������� �̵��ϰ� �ʹ�.
    // Ÿ�� �������� ȸ���ϰ� �ʹ�.
    // Ÿ���� ���ݹ����ȿ� ������ ���¸� �������� ��ȯ�ϰ� �ʹ�.
    // �ʿ�Ӽ� : ���ݹ���
    public float attackRange = 2;
    bool result = false;
    Vector3 randPos = Vector3.zero;
    private void Move()
    {
        // Ÿ�������� �̵��ϰ� �ʹ�.
        // 1. �������ʿ�(target - me)
        Vector3 dir = target.position - transform.position;
        float distance = dir.magnitude;
        dir.Normalize();
        dir.y = 0;

        // �� �þ� �����ȿ� ����,
        float dot = Vector3.Dot(transform.forward, dir);
        // �� ���溤��
        Debug.DrawLine(transform.position, transform.position + transform.forward * 5, Color.red);
        // Ÿ�������� ���ϴ� ����
        Debug.DrawLine(transform.position, transform.position + dir * 5, Color.red);

        // Ÿ������ �̵�
        if (true)//distance < moveToTargetRange && dot > 0.5f)
        {
            // Ÿ������ �̵��ϱ�
            agent.destination = target.position;
        }
        // �׷��� ������
        // Ÿ������ �̵��� �� ���� ���������� ��Ʈ�� �ϰ� �ʹ�.
        else
        {
            // ��Ʈ��
            // ���� �̵��� ���� ��ã���� ��
            if (result == false)
            {
                result = GetRandomPosition(transform.position, out randPos, 10);
            }
            // ���� ã�Ҵٸ�
            else
            {
                // -> �������� randPos �� �����ֱ�
                agent.destination = randPos;
                // -> �������� ���� �ٿԴٸ�
                if (Vector3.Distance(transform.position, randPos) < 0.1f)
                {
                    // -> �ٽ� ã�� ���� ������ ���ֱ�
                    result = false;
                }
            }
        }
        // 2. �̵��ϰ� �ʹ�.
        //cc.SimpleMove(dir * speed);
        // Enemy �� ������ dir �� ����
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);

        // Ÿ���� ���ݹ����ȿ� ������ ���¸� �������� ��ȯ�ϰ� �ʹ�.
        if(distance < attackRange)
        {
            m_state = EnemyState.Attack;
            currentTime = attackDelayTime;
            agent.enabled = false;
        }
    }

    // Ư�� ��ġ�� �������� �׺���̼��� ������ ��ġ�� �Ѱ��ִ´�.
    private bool GetRandomPosition(Vector3 position, out Vector3 randPos, float range = 3)
    {
        Vector3 center = Random.insideUnitSphere * range;
        center.y = 0;
        center += position;
        NavMeshHit hitInfo;
        bool result = NavMesh.SamplePosition(center, out hitInfo, range, 1);

        randPos = hitInfo.position;
        return result;
    }

    // �����ð��� �ѹ��� �����ϰ� �ʹ�.
    // �ʿ�Ӽ� : ���ݴ��ð�
    // Ÿ���� ���ݹ����� ����� ���¸� �̵����� ��ȯ�ϰ� �ʹ�.
    public float attackDelayTime = 2;
    private void Attack()
    {
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);

        currentTime += Time.deltaTime;
        if(currentTime > attackDelayTime)
        {
            currentTime = 0;
            print("attack!!!");
            anim.SetTrigger("Attack");
        }
        // Ÿ���� ���ݹ����� ����� ���¸� �̵����� ��ȯ�ϰ� �ʹ�.
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance > attackRange)
        {
            m_state = EnemyState.Move;
            anim.SetTrigger("Move");

            agent.enabled = true;
            //anim.Play("Move");
            //anim.CrossFade()
        }
    }

    // �ǰ� �̺�Ʈ �޾Ƽ� ó�� �Լ�
    // 3������� �׵��� ó������
    // �ʿ�Ӽ� : ü��
    // ü���� ���������� ���¸� �ǰ����� ��ȯ�ϰ� �ʹ�.
    // �׷��������� ���¸� �������� ��ȯ�ϰ� �ʹ�.
    // ���� ���°� �Ǹ� �浹���� �ʵ��� ó��
    // �˹�ó��
    // �ʿ�Ӽ� : �˹齺�ǵ�
    public float knockBackSpeed = 2;
    Vector3 knockEndPos;

    public int hp = 3;
    public void OnDamageProcess(Vector3 shootDirection)
    {
        agent.enabled = false;
        StopAllCoroutines();
        // 3������� �׵��� ó������
        hp--;
        // ü���� ���� �� ���¸� �������� ��ȯ�ϰ� �ʹ�.
        if (hp <= 0)
        {
            m_state = EnemyState.Die;
            cc.enabled = false;
            anim.SetTrigger("Die");
            StartCoroutine(Die());
        }
        // �׷��� ������ ���¸� �ǰ����� ��ȯ�ϰ� �ʹ�.
        else
        {
            m_state = EnemyState.Damage;
            anim.SetTrigger("Damage");
            //transform.position += shootDirection * knockBackSpeed;
            //cc.Move(shootDirection * knockBackSpeed);
            shootDirection.y = 0;
            knockEndPos = transform.position + shootDirection * knockBackSpeed;
            StartCoroutine(Damage());
        }

        currentTime = 0;
    }

    // �����ð� ��ٷȴٰ� ���¸� ���� ��ȯ�ϰ� �ʹ�.
    // �ʿ�Ӽ� : �ǰݴ��ð�
    public float damageDelayTime = 2;
    private IEnumerator Damage()
    {
        float curTime = 0;
        // �˹� �ִϸ��̼� ����
        // �˹� ��ġ�� ������ �� ���� �ݺ��ϰ� �ʹ�.
        while (curTime < damageDelayTime)
        {
            curTime += Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, knockEndPos, 10 * Time.deltaTime);

            yield return null;
        }
        transform.position = knockEndPos;

        // �����ð� ��ٷȴٰ�
        //yield return new WaitForSeconds(damageDelayTime);
        // ���¸� Idle �� ��ȯ�ϰ� �ʹ�.
        m_state = EnemyState.Idle;

        //currentTime += Time.deltaTime;
        //// 2. �ð��� �����ϱ�
        //if (currentTime > damageDelayTime)
        //{
        //    // 3. ���¸� �̵����� ��ȯ
        //    m_state = EnemyState.Idle;
        //    currentTime = 0;
        //}
    }

    // �Ʒ��� ��������� ����.
    // �������� ��������. -2
    public float dieSpeed = 0.5f;
    //private void Die()
    //{
    //    // �ִϸ��̼��� �� ����ǰ� 
    //    // 2 �� ��ٷȴٰ� 
    //    currentTime += Time.deltaTime;
    //    if (currentTime > 2)
    //    {
    //        // �Ʒ��� �������.
    //        transform.position += Vector3.down * dieSpeed * Time.deltaTime;
    //        if (transform.position.y < -3)
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    private IEnumerator Die()
    {
        // �ִϸ��̼��� �� ����ǰ� 
        // 2 �� ��ٷȴٰ� 
        yield return new WaitForSeconds(2);

        while (true)
        {
            // �Ʒ��� �������.
            transform.position += Vector3.down * dieSpeed * Time.deltaTime;
            if (transform.position.y < -3)
            {
                Destroy(gameObject);
                yield break;
            }
            yield return null;
        }
    }
}
