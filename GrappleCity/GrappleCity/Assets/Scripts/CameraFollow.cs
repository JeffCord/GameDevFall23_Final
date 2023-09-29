using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Drag your player here
    public float smoothSpeed = 0.125f; // Adjust this to change how smoothly the camera follows
    public Vector3 offset; // Adjust this to change the default position of the camera relative to the player

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
