using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    private Boolean isDeath = false;
    public float moveSpeed = 5f; // Скорость движения
    public float fallSpeed = 2f; // Скорость падения
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shark"))
        {
            Die();
        }
    }
    
    void Update()
    {
        if (!isDeath)
        {
            // Падение с учетом времени между кадрами
            transform.position += new Vector3(0, -fallSpeed * Time.deltaTime, 0);
            
            // Движение вправо
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector3(2, 2, 2);
            }

            // Движение влево
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector3(-2, 2, 2);
            }
        }
    }
    
    public void Die()
    {
        
        isDeath = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        
        // Сохраняем позицию смерти
        Vector3 deathPosition = transform.position;
        DeathDataSaver.SaveDeathPosition(deathPosition);
        StartCoroutine(TimeoutCoroutine(3f));
    }
    
    IEnumerator TimeoutCoroutine(float delay)
    {
        Debug.Log("Начало таймаута");
        yield return new WaitForSeconds(delay);
        Debug.Log("Таймаут завершён");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
