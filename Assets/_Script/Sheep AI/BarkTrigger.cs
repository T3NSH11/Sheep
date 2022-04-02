using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkTrigger : MonoBehaviour
{
    float MoveSpeed = 5;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Sheep")
        {
            collision.gameObject.GetComponent<SheepManager>().triggerPos = gameObject.transform.position;
            collision.gameObject.GetComponent<SheepManager>().BarkedAt = true;
            collision.gameObject.GetComponent<SheepManager>().movetimer = 2.2f;
            Debug.Log("trigger");

            // collision.gameObject.GetComponent<Rigidbody>().velocity += (triggerpos + collision.gameObject.transform.position).normalized * MoveSpeed;
            collision.gameObject.GetComponent<SheepManager>().barkMove = true;
            Debug.Log("moved");
        }
    }
}
