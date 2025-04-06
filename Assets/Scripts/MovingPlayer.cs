using System;
using UnityEngine;

public class Moving : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shark"))
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -PlayerStats.speedY, 0);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(PlayerStats.speedX, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-PlayerStats.speedX, 0, 0);
        }
    }
}
