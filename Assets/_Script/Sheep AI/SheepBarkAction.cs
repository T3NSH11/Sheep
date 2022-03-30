using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBarkAction : MonoBehaviour
{
    GameObject Sheep;
    float MoveSpeed = 3;
    bool movesheep = false;
    Vector3 triggerpos;
    float movetimer;
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
        if(Sheep.GetComponent<SheepManager>().BarkedAt == true)
        {
            movetimer += Time.deltaTime;
        }

        if (movetimer > 3)
        {
            Sheep.GetComponent<SheepManager>().BarkedAt = false;
        }
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Sheep")
        {
            Sheep.GetComponent<SheepManager>().BarkedAt = true;
            Sheep = collision.gameObject;
            movesheep = true;
            triggerpos = transform.position;
            Debug.Log("trigger");
        }
    }
}
