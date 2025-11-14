using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float offsetZ = -10f;

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(
            target.position.x,
            target.position.y,
            offsetZ
        );

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
