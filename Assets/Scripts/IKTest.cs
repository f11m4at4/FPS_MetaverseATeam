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

    // Ư�� ��ü�� �ٶ󺸵��� �ϰ� �ʹ�.
    // �ʿ�Ӽ� : Ÿ��
    public Transform target;
    public Transform handTarget;
    private void OnAnimatorIK(int layerIndex)
    {
        // �Ӹ� IK
        // Ư�� ��ü�� �ٶ󺸵��� �ϰ� �ʹ�.
        anim.SetLookAtWeight(1);
        anim.SetLookAtPosition(target.position);

        // �� IK
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, handTarget.position);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, handTarget.rotation);
    }
}
