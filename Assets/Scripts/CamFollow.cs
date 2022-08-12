using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Campos 를 따라다니고 싶다.
// 필요속성 : campos, 속도
public class CamFollow : MonoBehaviour
{
    // 필요속성 : campos, 속도
    public Transform campos;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Campos 를 따라다니고 싶다.
        transform.position = Vector3.Lerp(transform.position, campos.position, speed * Time.deltaTime);
        // 회전
        transform.forward = Vector3.Lerp(transform.forward, campos.forward, speed * Time.deltaTime);
    }
}
