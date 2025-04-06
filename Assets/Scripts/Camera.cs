using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, player.transform.position.y, -10);
    }
}
