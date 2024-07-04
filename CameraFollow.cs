using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow Settings")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);
    [SerializeField] private float followSpeed = 0.125f;
    [SerializeField] private bool shouldFollow = true;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (shouldFollow && target != null)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followSpeed);
            transform.position = smoothPosition;
        }
    }
}
