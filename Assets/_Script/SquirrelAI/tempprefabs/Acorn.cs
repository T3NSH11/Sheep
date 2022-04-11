using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float acornSpeed;
    private GameObject sheep;
    private Vector3 target;
    SquirrelMonoAI squirrelMonoAI;
    public GameObject squirrel; 
    void Start()
    {
        squirrel = GameObject.FindGameObjectWithTag("Squirrel");
        
    }

    // Update is called once per frame
    void Update()
    {

        sheep = squirrel.gameObject.GetComponent<SquirrelManager>().targetSheep;

        if (sheep != null)
        {
            sheep = squirrel.gameObject.GetComponent<SquirrelManager>().targetSheep;
        }

        if (sheep != null)
        {
            target = sheep.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, acornSpeed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyAcorn();
            }

        }
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Sheep"))
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
