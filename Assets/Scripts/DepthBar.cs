using TMPro;
using UnityEngine;

public class DepthBar : MonoBehaviour
{
    public TextMeshProUGUI depthText;  // Переменная для хранения ссылки на текстовый объект

    void Start()
    {
        // Убедись, что ты добавил объект в инспектор
        if (depthText != null)
        {
            depthText.text = "Глубина: 0 м"; // Начальное значение
        }
    }

    void Update()
    {
        // Обновляем текст с текущим значением глубины
        if (depthText != null)
        {
            depthText.text = "Глубина погружения " + PlayerStats.depth.ToString("F1") + " м";
        }
    }
}
