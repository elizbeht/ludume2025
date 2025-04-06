using System;
using UnityEngine;

public class MovingFIsh : MonoBehaviour
{
    GameObject player; 
    Int16 direction;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player.transform.position.x > transform.position.x)
        {
            direction = 1;
            transform.Rotate(0,0,0);
        }
        else
        {
            direction = -1;
            transform.Rotate(0,200,0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.y - player.transform.position.y) < 6)
        {
            transform.position += new Vector3(direction * 0.05f, -0.03f, 0);
        }
    }
}
