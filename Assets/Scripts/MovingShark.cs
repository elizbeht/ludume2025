using System;
using UnityEngine;
using System.Collections;

public class MovingShark : MonoBehaviour
{
    GameObject player;
    Int16 direction;
    private Boolean isEating = false;
    Animator animator;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEating = true;
            StartCoroutine(TimeoutCoroutine(1.5f)); // Ждём 3 секунды
        }
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

    void Update()
    {
        if (!isEating) {
            if (Math.Abs(transform.position.y - player.transform.position.y) < 6)
            {
                transform.position += new Vector3(direction * 0.07f, -0.02f, 0);
            }
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 2f)
        {
            if (animator != null)
            {
                animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }
    
    IEnumerator TimeoutCoroutine(float delay)
    {
        Debug.Log("Начало таймаута");
        yield return new WaitForSeconds(delay);
        Debug.Log("Таймаут завершён");
        isEating = false;
        // Здесь код, который нужно выполнить после таймаута
    }
}
