using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    Collider planecollider;
    public Rigidbody rb;
    public GameObject visualCue;
    //public LayerMask groundLayer;
    public Collider GroundCollider;
    public float speed;
    Vector3 targetPosition;

    private void Start()
    {
        visualCue.SetActive(false);
        targetPosition = transform.position;
    }

    void Update()
    {
        InputManager();
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
    private void InputManager()
    {
        visualCue.gameObject.transform.position = targetPosition;

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray;

            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider == GroundCollider)
            {
                visualCue.SetActive(true);
                targetPosition = hit.point;

            }


            if (visualCue.transform.position == targetPosition)
            {

                visualCue.SetActive(false);
            }
        }

        if (Vector3.Distance(targetPosition, transform.position) > 3)
        {
            transform.LookAt(targetPosition);
        }

        rb.velocity = (targetPosition - transform.position).normalized * speed * Time.deltaTime;
    }
}
