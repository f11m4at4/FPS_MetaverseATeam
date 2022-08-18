using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Sine : CameraShakeBase 
{
    float theta = 0;
    // 카메라셰이크 재생
    // transform : 카메라셰이크 할 카메라트랜스폼
    // info : 사용자가 설정한 카메라셰이크 정보
    public override void Play(Transform transform, CameraShakeInfo info)
    {
        // P = P0 + vt
        theta += info.sinSpeed * Time.deltaTime;
        transform.position = originPos + Vector3.up * Mathf.Sin(theta) * info.amplitude;
    }

    // 카메라셰이크 정지
    // transform : 카메라셰이크 할 카메라트랜스폼
    public override void Stop(Transform transform)
    {
        transform.position = originPos;
        theta = 0;
    }
}
