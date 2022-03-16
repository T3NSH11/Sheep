using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    Collider planecollider;
    Rigidbody rb;
    public GameObject visualCue;

    public Collider[] groundColliders;
    public float speed;
    Vector3 targetPosition;


    private void Start()
    {
        visualCue.SetActive(false);
        targetPosition = transform.position;
    }

    void Update()
    {
        //transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));

        visualCue.gameObject.transform.position = targetPosition;



        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray;

            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                visualCue.SetActive(true);
                targetPosition = hit.point;


            }


            if (visualCue.transform.position == targetPosition)
            {


                visualCue.SetActive(false);
            }





        }

        transform.LookAt(targetPosition);
        this.gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        //bruh

        



    }
}
