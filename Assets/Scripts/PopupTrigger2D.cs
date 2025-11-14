using UnityEngine;

public class PopupTrigger2D : MonoBehaviour
{
    public GameObject cloud; // UI хмарка або будь-який об'єкт

    void Start()
    {
        if (cloud != null)
            cloud.SetActive(false);
        else
            Debug.LogWarning("PopupTrigger2D: cloud не прив'язана!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D with: " + other.name + " tag=" + other.tag);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger -> show cloud");
            cloud.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit2D with: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger -> hide cloud");
            cloud.SetActive(false);
        }
    }
}
