using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject[] moveableObjects;
    Vector3 rb;
    // Start is called before the first frame update
    void Start()
    {
        //moveableObjects = GameObject.FindGameObjectsWithTag("Sheep");
        moveableObjects = GameObject.FindGameObjectsWithTag("Wolf");
        moveableObjects = GameObject.FindGameObjectsWithTag("Squirrel");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < moveableObjects.Length; i++)
        {
            rb = moveableObjects[i].GetComponent<Rigidbody>().velocity;

            Quaternion desiredRotation = Quaternion.LookRotation(rb);
            moveableObjects[i].transform.rotation = Quaternion.Slerp(moveableObjects[i].transform.rotation, desiredRotation, Time.deltaTime);
        }
    }
}
