using UnityEngine;

using UnityEngine.UI;

using TMPro; // Необходимо для работы с TextMeshPro

public class OxygenSystem : MonoBehaviour
{
 public float maxOxygen = 100f;
 
 public float currentOxygen;

 public float oxygenDecrease = 5f;

 public TextMeshProUGUI hungerText; // Добавляем ссылку на Text

 void Start()
 {
    currentOxygen= maxOxygen;
 }
 void Update()
 {
    currentOxygen -= oxygenDecrease * Time.deltaTime;
    currentOxygen = Mathf.Clamp(currentOxygen,0,maxOxygen);
    if (hungerText != null)
            hungerText.text = "Кислород: " + Mathf.RoundToInt(currentOxygen).ToString() + "%"; // Обновляем текст голода

 }
 
 public void Eat(float amount){
    currentOxygen +=amount;
    currentOxygen = Mathf.Clamp(currentOxygen,0,maxOxygen);
 }
 void GameOver()
 {
    Time.timeScale = 0f;
    // GameObject GameOverPanel = GameObject.Find("GameOverPanel");
    // if(GameOverPanel != null)
    //     GameOverPanel.SetActvive(true);
 }
}
