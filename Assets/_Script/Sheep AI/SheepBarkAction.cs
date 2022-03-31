using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBarkAction : MonoBehaviour
{
    float MoveSpeed = 5;
    Vector3 triggerpos;
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Sheep")
        {
            collision.gameObject.GetComponent<SheepManager>().BarkedAt = true;
            collision.gameObject.GetComponent<SheepManager>().movetimer = 2.2f;
            triggerpos = transform.position;
            Debug.Log("trigger");
            collision.gameObject.GetComponent<Rigidbody>().velocity += (triggerpos + collision.gameObject.transform.position).normalized * MoveSpeed;
            Debug.Log("moved");
        }
    }
}
