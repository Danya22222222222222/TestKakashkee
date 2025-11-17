using UnityEngine;

public class Door2 : MonoBehaviour
{
    public void OpenDoor()
    {
        Debug.Log("Door opened!");
        // “ут робиш ан≥мац≥ю, звук, або просто:
        gameObject.SetActive(false);
    }
}
