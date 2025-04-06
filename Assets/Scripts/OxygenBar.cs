using UnityEngine;
using UnityEngine.UI;

public class OxygenManager : MonoBehaviour
{
    public Sprite[] oxygenSprites; // Array to hold different sprites for different oxygen levels
    private Image spriteRenderer; // Reference to the SpriteRenderer component
    private GameObject player;
    private float oxygenLevel = PlayerStats.oxygen;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        spriteRenderer = GetComponent<Image>(); // Get the SpriteRenderer component attached to this GameObject
        UpdateOxygenImage(); // Update the sprite when the game starts
    }

    void Update()
    {
        // For demonstration, we decrease the oxygen level when the spacebar is pressed
        oxygenLevel = PlayerStats.oxygen;
        // Update the sprite every frame based on the current oxygen level
        UpdateOxygenImage();
    }

    void UpdateOxygenImage()
    {
        // Change the sprite based on the oxygen level
        if (oxygenLevel > 800)
        {
            spriteRenderer.sprite = oxygenSprites[0]; // 100% oxygen sprite
        }
        else if (oxygenLevel > 600)
        {
            spriteRenderer.sprite = oxygenSprites[1]; // 75% oxygen sprite
        }
        else if (oxygenLevel > 400)
        {
            spriteRenderer.sprite = oxygenSprites[2]; // 50% oxygen sprite
        }
        else if (oxygenLevel > 200)
        {
            spriteRenderer.sprite = oxygenSprites[3]; // 25% oxygen sprite
        }
        else
        {
            spriteRenderer.sprite = oxygenSprites[4]; // 0% oxygen sprite
        }

    }

    // Function to decrease the oxygen level
    public void DecreaseOxygen(float amount)
    {
        oxygenLevel -= amount; // Reduce the oxygen level
        if (oxygenLevel < 0) oxygenLevel = 0; // Ensure oxygen level doesn't go below 0
    }
}
