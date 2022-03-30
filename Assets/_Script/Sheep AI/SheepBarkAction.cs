using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBarkAction : MonoBehaviour
{
    GameObject Sheep;
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
            Sheep = collision.gameObject;
            Sheep.GetComponent<SheepManager>().BarkedAt = true;
            Sheep.GetComponent<SheepManager>().movetimer = 2.1f;
            triggerpos = transform.position;
            Debug.Log("trigger");
            Sheep.GetComponent<Rigidbody>().velocity += (triggerpos + Sheep.transform.position).normalized * MoveSpeed;
            Debug.Log("moved");
        }
    }
}
