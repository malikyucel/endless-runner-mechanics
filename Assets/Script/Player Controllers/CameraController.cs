using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPos;

    public float smoothSpeed = 0.3f;
    private Vector3 offset = new Vector3(0, 3, -3);

    private void Update()
    {
        Vector3 desired = playerPos.position + offset;
        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, desired, smoothSpeed), Quaternion.Euler(15,0,0));
    }
}
