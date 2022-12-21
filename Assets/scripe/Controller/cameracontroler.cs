using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroler : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;
    public float zoomspeed = 4f;
    public float minzoom = 5f;
    public float maxzoom = 15f;

    private float currentzoom = 10f;

    public float pitch = 2f;

    public float yawSpeed = 100f;
    private float currentYaw = 0f;

    private void Update()
    {
        currentzoom -= Input.GetAxis("Mouse ScrollWheel") * zoomspeed;
        currentzoom = Mathf .Clamp(currentzoom, minzoom, maxzoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
    void LateUpdate()
    {
        transform.position = target.position - offset * currentzoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
