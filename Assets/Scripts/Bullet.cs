using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        // 총알을 던져버리면 된다.
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);

        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        // v = v0 + at
    }
}
