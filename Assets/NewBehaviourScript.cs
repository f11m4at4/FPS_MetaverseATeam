using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    string note = "";
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(Input.GetButtonDown("Jump"))
        {
            note += currentTime + "\n";
        }

        if(Input.GetButtonDown("Fire2"))
        {
            print(note);
        }
    }
}
