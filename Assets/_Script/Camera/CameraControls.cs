using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float RotationSpeed;
    public GameObject Camera;
    public GameObject Player;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        if (Input.GetMouseButton(2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, 5.0f, 90f);

            yRotation -= mouseX;

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
            transform.position -= new Vector3(mouseX, 0, mouseY);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = Player.transform.position;
        }


        Camera.transform.position -= (Camera.transform.position - transform.position).normalized * Input.mouseScrollDelta.y;

    }
}
