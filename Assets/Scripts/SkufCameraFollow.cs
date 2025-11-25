using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        // ѕри старт≥ шукаЇмо гравц€
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            target = player.transform;
    }

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}
