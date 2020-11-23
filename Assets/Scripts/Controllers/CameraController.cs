using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    public float zoomSpeed = 1f;
    public int minZoom = 2;
    public int maxZoom = 10;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float currentZoom = 8f;
    private float currentYaw = 0f;

    public float RotationsSpeed = 5.0f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

            offset = camTurnAngle * offset;
        }

        transform.position = player.position - offset * currentZoom;
        transform.LookAt(player.position + Vector3.up * pitch);

        transform.RotateAround(player.position, Vector3.up, currentYaw);
    }
}
