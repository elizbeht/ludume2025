using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    private bool isDeath = false;
    public float moveSpeed = 5f; // Скорость движения
    public float fallSpeed = 2f; // Скорость падения
    public AudioSource audioSource; // Ссылка на компонент AudioSource
    public AudioClip hitSound; // Звук поражения
    
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
            transform.position += new Vector3(0, -PlayerStats.speedY * Time.deltaTime, 0);
            
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
            
            PlayerStats.depth += 1;
            Debug.Log(PlayerStats.depth);
        }
    }
    
    public void Die()
    {
        isDeath = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        
        // Сохраняем позицию смерти
        Vector3 deathPosition = transform.position;
        DeathDataSaver.SaveDeathPosition(deathPosition);
        StartCoroutine(TimeoutCoroutine(1f));
        PlayerStats.ateFishes=0;
        PlayerStats.depth=0;
        
    }
    
    IEnumerator TimeoutCoroutine(float delay)
    {
        PlayHitSound();
        Debug.Log("Начало таймаута");
        yield return new WaitForSeconds(delay);
        Debug.Log("Таймаут завершён");
        
        SceneManager.LoadScene("StartScene");
    }

    void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

}

