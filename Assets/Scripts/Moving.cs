using System;
using UnityEngine;

public class Moving : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -0.05f, 0);
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.15f, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.15f, 0, 0);
        }
    }
}
