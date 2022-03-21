using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float acornSpeed;
    private Transform sheep;
    private Vector3 target;
    void Start()
    {
        sheep = GameObject.FindGameObjectWithTag("Sheep").transform;
        target = new Vector3(sheep.position.x, sheep.position.y, sheep.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, acornSpeed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyAcorn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            DestroyAcorn();
        }
    }

    void DestroyAcorn()
    {

        Destroy(gameObject);
    }
}
