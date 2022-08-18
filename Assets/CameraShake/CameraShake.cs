using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ī�޶����ũ�� ���۽�Ű�� Ŭ����
// �ʿ�Ӽ� : Ÿ��ī�޶�, ����ð�, ī�޶����ũ����, ī�޶����ũŸ��, �����ų ī�޶����ũŬ����
public class CameraShake : MonoBehaviour
{
    //Ÿ��ī�޶�
    public Transform targetCamera;
    //����ð�
    public float playTime = 0.1f;
    [SerializeField]
    //ī�޶����ũ����
    CameraShakeInfo info;

    //ī�޶����ũŸ��
    public enum CameraShakeType
    {
        Random,
        Sine,
        Animation
    }
    public CameraShakeType cameraShakeType = CameraShakeType.Random;
    //�����ų ī�޶����ũŬ����
    CameraShakeBase cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = CreateCameraShake(cameraShakeType);
    }

    public static CameraShakeBase CreateCameraShake(CameraShakeType type)
    {
        switch(type)
        {
            case CameraShakeType.Random:
                return new CS_Random();
            case CameraShakeType.Sine:
                return new CS_Sine();
            case CameraShakeType.Animation:
                return new CS_Animation();
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            PlayCameraShake();
        }
    }

    void PlayCameraShake()
    {
        // ī�޶����ũ Ÿ���� �ִϸ��̼��� �ƴҰ��
        if (cameraShakeType != CameraShakeType.Animation)
        {
            StopAllCoroutines();
            StartCoroutine(Play());
        }
        // �ִϸ��̼��� ���
        else
        {
            cameraShake.Play(targetCamera, info);
        }
    }

    // ����ð����� ī�޶����ũ ����
    IEnumerator Play()
    {
        cameraShake.Init(targetCamera.position);

        float currentTime = 0;
        // ����ð����� 
        while (currentTime < playTime)
        {
            currentTime += Time.deltaTime;
            //ī�޶����ũ ����
            cameraShake.Play(targetCamera, info);
            yield return null;
        }
        // ������ Stop
        cameraShake.Stop(targetCamera);
    }
}
