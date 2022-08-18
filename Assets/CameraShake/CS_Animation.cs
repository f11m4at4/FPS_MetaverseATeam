using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Animation : CameraShakeBase 
{
    // ī�޶����ũ ���
    // transform : ī�޶����ũ �� ī�޶�Ʈ������
    // info : ����ڰ� ������ ī�޶����ũ ����
    public override void Play(Transform transform, CameraShakeInfo info)
    {
        transform.GetComponent<Animation>().Play(PlayMode.StopAll);
    }

    // ī�޶����ũ ����
    // transform : ī�޶����ũ �� ī�޶�Ʈ������
    public override void Stop(Transform transform)
    {
        transform.GetComponent<Animation>().Stop();
    }
}
