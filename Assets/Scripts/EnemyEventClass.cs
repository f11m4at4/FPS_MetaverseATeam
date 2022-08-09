using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventClass : MonoBehaviour
{
    void OnAttack()
    {
        PlayerHealth.Instance.HP--;
    }
}
