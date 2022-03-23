using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float RotationSpeed;
    public GameObject Camera;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        Camera.transform.position += new Vector3(0, -Input.mouseScrollDelta.y * 35 * Time.deltaTime, 0);
    }
}
