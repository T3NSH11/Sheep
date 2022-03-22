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

            transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime),(-Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);

        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        Camera.transform.position += new Vector3(0, -Input.mouseScrollDelta.y * 35 * Time.deltaTime, 0);
    }
}
