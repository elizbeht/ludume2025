using UnityEngine;

public class MovingFish : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float horizontalSpeed = 2.5f; // Скорость горизонтального движения
    [SerializeField] private float verticalSpeed = 1.5f;   // Скорость вертикального движения
    [SerializeField] private float followThreshold = 6f;   // Порог по Y для начала движения

    private GameObject player; 
    private int direction; // Изменил Int16 на int (более стандартный выбор)
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure player has 'Player' tag.");
        }
    }

    void Start()
    {
        DetermineInitialDirection();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats.ateFishes+=1;
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (ShouldFollowPlayer())
        {
            MoveFish();
        }
    }

    private void DetermineInitialDirection()
    {
        if (player != null)
        {
            direction = player.transform.position.x > transform.position.x ? 1 : -1;
            transform.rotation = Quaternion.Euler(0, direction == 1 ? 0 : 180, 0);
            // Исправил поворот с 200 на 180 градусов (стандартный разворот)
        }
    }

    private bool ShouldFollowPlayer()
    {
        return player != null && Mathf.Abs(transform.position.y - player.transform.position.y) < followThreshold;
    }

    private void MoveFish()
    {
        Vector3 movement = new Vector3(
            direction * horizontalSpeed * Time.deltaTime,
            -verticalSpeed * Time.deltaTime,
            0);
            
        transform.position += movement;
    }
}