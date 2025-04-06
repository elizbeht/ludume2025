using System;
using UnityEngine;
using System.Collections;

public class MovingShark : MonoBehaviour
{
    GameObject player;
    Int16 direction;
    private Boolean isEating = false;
    Animator animator;
    
    [Header("Movement Settings")]
    public float horizontalSpeed = 3.5f; // Скорость горизонтального движения
    public float verticalSpeed = 1.0f;   // Скорость вертикального движения
    public float attackDistance = 2f;    // Дистанция для атаки
    public float followHeightThreshold = 6f; // Порог по Y для начала преследования
    
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
            StartCoroutine(TimeoutCoroutine(1.5f));
        }
    }

    void Start()
    {
        if (player.transform.position.x > transform.position.x)
        {
            direction = 1;
            transform.Rotate(0, 0, 0);
        }
        else
        {
            direction = -1;
            transform.Rotate(0, 180, 0); // Исправлено с 200 на 180 градусов
        }
    }

    void Update()
    {
        if (!isEating) 
        {
            if (Math.Abs(transform.position.y - player.transform.position.y) < followHeightThreshold)
            {
                // Движение с учетом Time.deltaTime
                transform.position += new Vector3(
                    direction * horizontalSpeed * Time.deltaTime, 
                    -verticalSpeed * Time.deltaTime, 
                    0);
            }
        }
        
        // Проверка дистанции для атаки
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        bool shouldAttack = distanceToPlayer < attackDistance;
        
        if (animator != null)
        {
            animator.SetBool("isAttacking", shouldAttack);
        }
    }
    
    IEnumerator TimeoutCoroutine(float delay)
    {
        Debug.Log("Начало таймаута");
        yield return new WaitForSeconds(delay);
        Debug.Log("Таймаут завершён");
        isEating = false;
    }
}