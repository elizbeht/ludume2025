    using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndColliede : MonoBehaviour
{

    public string sceneToLoad = "StartScene";

       void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("SSS");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
