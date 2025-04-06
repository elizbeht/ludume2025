using TMPro;
using UnityEngine;

class AteFish : MonoBehaviour{
    public TextMeshProUGUI numbFish;  // Переменная для хранения ссылки на текстовый объект

    void Start()
    {
        // Убедись, что ты добавил объект в инспектор
        if (numbFish != null)
        {
            numbFish.text = "Cъедено рыб: 0"; // Начальное значение
        }
    }

    void Update()
    {
        // Обновляем текст с текущим значением глубины
        if (numbFish != null)
        {
            numbFish.text = "Съедено рыб: " + PlayerStats.ateFishes;
        }
    }
}