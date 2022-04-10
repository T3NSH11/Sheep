using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelMonoAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float scurryDistance;


    private float coolDownTimer;
    public float startCoolDownTimer;
    public GameObject acorn;
    private Transform sheep;
    int acornAmount = 1;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Sheep").Length != 0)
        {
            sheep = GameObject.FindGameObjectWithTag("Sheep").transform;
        }
       
        coolDownTimer = startCoolDownTimer;
       
    }

    // Update is called once per frame
    void Update()
    {

        //acorn = GameObject.FindGameObjectWithTag("Acorn");
        
        if ( sheep != null && Vector3.Distance(transform.position, sheep.position) > stoppingDistance) //will move closer to the target
        {

            transform.position = Vector3.MoveTowards(transform.position, sheep.position, speed * Time.deltaTime);

        }
        else if (sheep != null && Vector3.Distance(transform.position, sheep.position) > stoppingDistance && Vector3.Distance(transform.position, sheep.position) > scurryDistance) //if near enough the stop distance it will stop moving
        {

            transform.position = this.transform.position; //resseting squirrel pos to make it stop moving at a certain distance 
        }
        else if (sheep != null && Vector3.Distance(transform.position, sheep.position) < scurryDistance) //back away
        {

            transform.position = Vector3.MoveTowards(transform.position, sheep.position, -speed * Time.deltaTime); //makes squirrel back away if too close

        }


        if (coolDownTimer <= 0 && GameObject.FindGameObjectWithTag("Acorn") == null)
        {
            Instantiate(acorn, transform.position, Quaternion.identity);
            coolDownTimer = startCoolDownTimer;

        } else
        {
            coolDownTimer -= Time.deltaTime;
        }
      
    }
}
