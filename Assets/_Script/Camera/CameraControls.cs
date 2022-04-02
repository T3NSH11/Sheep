using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float RotationSpeed;
    public float Smoothness;
    public float MoveSpeed;
    public GameObject Camera;
    public GameObject Player;
    Vector3 offset;
    Vector3 CamPosition;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Confined;
        offset = transform.position - Player.transform.position;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {

        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;

        float MovemouseX = Input.GetAxis("Mouse X") * MoveSpeed * Time.deltaTime;
        float MovemouseY = Input.GetAxis("Mouse Y") * MoveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            CamPosition = Player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, CamPosition, Smoothness * Time.fixedDeltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Euler(-40, 0, 0);
            transform.position -= new Vector3(MovemouseX, 0, MovemouseY);
        }

        if (Input.GetMouseButton(2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            xRotation += mouseY;

            //xRotation = Mathf.Clamp(xRotation, 5.0f, 90f);

            yRotation += mouseX;

            transform.localRotation = Quaternion.Euler(-40, yRotation, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        Camera.transform.position -= (Camera.transform.position - transform.position).normalized * Input.mouseScrollDelta.y * 2;
    }
}
