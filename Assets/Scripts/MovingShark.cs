using System;
using UnityEngine;

public class MovingShark : MonoBehaviour
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
        }
        else
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.y - player.transform.position.y) < 6)
        {
            transform.position += new Vector3(direction * 0.07f, -0.02f, 0);
        }
    }
}