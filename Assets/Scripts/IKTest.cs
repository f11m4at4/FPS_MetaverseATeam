using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTest : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // 특정 물체를 바라보도록 하고 싶다.
    // 필요속성 : 타겟
    public Transform target;
    public Transform handTarget;
    private void OnAnimatorIK(int layerIndex)
    {
        // 머리 IK
        // 특정 물체를 바라보도록 하고 싶다.
        anim.SetLookAtWeight(1);
        anim.SetLookAtPosition(target.position);

        // 손 IK
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, handTarget.position);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, handTarget.rotation);
    }
}
