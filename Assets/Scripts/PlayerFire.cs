using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� �߻��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
// �ʿ�Ӽ� : �Ѿ˰���, �ѱ�
public class PlayerFire : MonoBehaviour
{
    // �ʿ�Ӽ� : �Ѿ˰���, �ѱ�
    public GameObject bulletFactory;
    public Transform firePosition;
    // �Ѿ�����
    public Transform bulletImpact;
    ParticleSystem bulletPS;
    AudioSource bulletAudio;

    // Start is called before the first frame update
    void Start()
    {
        bulletPS = bulletImpact.GetComponent<ParticleSystem>();
        bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����ڰ� �߻��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
        // 1. ����ڰ� �߻��ư�� �������ϱ�
        if (Input.GetButtonDown("Fire1"))
        {
            bulletAudio.Stop();
            bulletAudio.Play();
            //ShootBullet();
            ShootRay();
        }
    }

    void ShootRay()
    {
        // Ray �� �̿��ؼ� �Ѿ��� �߻��ϰ� �ʹ�.
        // Ray �ʿ�
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit
        RaycastHit hitInfo;

        // �÷��̾ ���� �浹�ϰ� �ϰ� �ʹ�.
        int layer = 1 << gameObject.layer;

        // Ray ������.
        // -> ���� �浹�ߴٸ�
        if (Physics.Raycast(ray, out hitInfo, 1000, ~layer))
        {
            // -> �ε��� ������ ����ȿ�� ǥ��
            // 1. ������ �ε��� �������� ��ġ
            bulletImpact.position = hitInfo.point;
            // �ε��� ������ ���ϴ� �������� ������ Ƣ����
            bulletImpact.forward = hitInfo.normal;
            // 2. ȿ�� ���
            bulletPS.Stop();
            bulletPS.Play();

            // ���� ���� �༮�� Enemy ���
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy)
            {
                // -> �ǰ� �̺�Ʈ�� ȣ������
                enemy.OnDamageProcess(ray.direction);

            }
        }
    }

    private void ShootBullet()
    {
        // 2. �Ѿ��� �ʿ�
        GameObject bullet = Instantiate(bulletFactory);
        // 3. �Ѿ��� �߻��ϰ� �ʹ�.
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }
}
