using UnityEngine;

public class KeyHoleTrigger : MonoBehaviour
{
    // Сюди ми в інспекторі Unity перетягнемо наші двері
    public Door2 doorToOpen;

    // Тег, який ми дамо нашому "ключовому" об'єкту
    public string requiredTag = "MovableKey";

    // Ця функція спрацьовує, коли якийсь інший Collider
    // входить у наш тригер (у нашу "дірку")
    private void OnTriggerEnter(Collider other)
    {
        // Перевіряємо, чи об'єкт, що увійшов, має потрібний нам тег
        if (other.CompareTag(requiredTag))
        {
            Debug.Log($"Правильний об'єкт ({other.name}) увійшов у тригер!");

            // Якщо двері ще не відкриті, даємо їм команду
            if (doorToOpen != null)
            {
                doorToOpen.OpenDoor();
            }

            // Опціонально: можна знищити ключ або вимкнути цей тригер,
            // щоб він не спрацьовував повторно
            // Destroy(other.gameObject); // Знищити об'єкт-ключ
            // this.enabled = false; // Вимкнути цей скрипт
        }
    }
}