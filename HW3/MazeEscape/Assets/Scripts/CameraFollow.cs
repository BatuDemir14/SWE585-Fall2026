using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 3.5f;
    public float height = 6f;
    public float smoothSpeed = 6f;

    void LateUpdate()
    {
        // stay behind and above the player
        Vector3 wantedPosition = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.2f);
    }
}
