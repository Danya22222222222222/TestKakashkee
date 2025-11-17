using UnityEngine;

public class AltarTrigger : MonoBehaviour
{
    public string requiredTag;     // який предмет підходить
    public Level3Manager manager;  // посилання на менеджер рівня
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag(requiredTag))
        {
            activated = true;
            manager.AltarActivated();

            Debug.Log("Алтарь активовано: " + requiredTag);
        }
    }
}
