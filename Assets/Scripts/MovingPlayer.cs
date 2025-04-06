using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    private Boolean isDeath = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shark"))
        {
            Die();
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
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-0.15f, 0, 0);
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
