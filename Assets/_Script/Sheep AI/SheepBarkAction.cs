using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBarkAction : MonoBehaviour
{
    GameObject Sheep;
    float MoveSpeed = 2;
    bool movesheep = false;
    Vector3 triggerpos;
    void Start()
    {

    }

    void Update()
    {
        if (movesheep)
        {
            Sheep.GetComponent<Rigidbody>().velocity += (triggerpos + Sheep.transform.position).normalized * MoveSpeed;
            movesheep = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Sheep")
        {
            Sheep = collision.gameObject;
            movesheep = true;
            triggerpos = transform.position;
            Debug.Log("trigger");
        }
    }
}
