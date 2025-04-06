using System.Collections;
using UnityEngine;

public class SlowingDownHeroSystem : MonoBehaviour
{
    public float slowFactor = 0.025f;
    public float slowDuration = 5f;
    private bool isSlowing = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isSlowing)
        {
            StartCoroutine(ApplySlow());
        }
    }

    IEnumerator ApplySlow()
    {
        isSlowing = true;
        float originalSpeed = PlayerStats.speedY;

        PlayerStats.speedY = slowFactor;
        yield return new WaitForSeconds(slowDuration);

        PlayerStats.speedY = originalSpeed;
        isSlowing = false;
    }
}
