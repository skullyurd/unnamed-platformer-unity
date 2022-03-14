using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetCamera;
    [SerializeField] public Vector3 offset;

    void Update()
    {
        transform.position = targetCamera.position + offset;
        transform.LookAt(targetCamera);
    }
}
