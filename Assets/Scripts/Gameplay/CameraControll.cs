using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControll : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        Vector3 newOffset = RageMode.Instance.IsRageMode ? offset + Vector3.forward * 25 : offset;
        Vector3 desiredPosition = target.position - newOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        transform.position = smoothedPosition;
    }
}
