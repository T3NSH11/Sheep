using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float acornSpeed;
    private Transform sheep;
    private Vector3 target;
    SquirrelMonoAI squirrelMonoAI;
    void Start()
    {
        if (sheep != null)
        {

            sheep = GameObject.FindGameObjectWithTag("Sheep").transform;

        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sheep != null)
        {
            target = new Vector3(sheep.position.x, sheep.position.y, sheep.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, acornSpeed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyAcorn();
            }

        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            DestroyAcorn();

        }
        /*if (other.CompareTag(" GreenSheep"))
        {
            //disable / slow down greensheep movement here.
            DestroyAcorn();
        }
        */
    }

    void DestroyAcorn()
    {
        
        Destroy(gameObject);
    }
    
}
