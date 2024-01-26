using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1f;
    public Vector3 offset;
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, lerpSpeed);
        transform.position = newPosition;
    }
}
