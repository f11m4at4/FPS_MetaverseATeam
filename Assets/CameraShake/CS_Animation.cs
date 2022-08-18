using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Animation : CameraShakeBase 
{
    // 카메라셰이크 재생
    // transform : 카메라셰이크 할 카메라트랜스폼
    // info : 사용자가 설정한 카메라셰이크 정보
    public override void Play(Transform transform, CameraShakeInfo info)
    {
        transform.GetComponent<Animation>().Play(PlayMode.StopAll);
    }

    // 카메라셰이크 정지
    // transform : 카메라셰이크 할 카메라트랜스폼
    public override void Stop(Transform transform)
    {
        transform.GetComponent<Animation>().Stop();
    }
}
