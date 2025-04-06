using System;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Boolean isDeath = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shark"))
        {
            isDeath = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
            transform.position += new Vector3(0, -0.05f, 0);
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.15f, 0, 0);
                 transform.localScale = new Vector3(1, 1, 1);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-0.15f, 0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
