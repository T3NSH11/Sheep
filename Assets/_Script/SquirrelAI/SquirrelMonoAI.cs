using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelMonoAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float scurryDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private float coolDownTimer;
    public float startCoolDownTimer;
    public GameObject acorn;
    private Transform sheep;


    // Start is called before the first frame update
    void Start()
    {
        sheep = GameObject.FindGameObjectWithTag("Sheep").transform;
        coolDownTimer = startCoolDownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, sheep.position) > stoppingDistance) //will move closer to the target
        {

            transform.position = Vector3.MoveTowards(transform.position, sheep.position, speed * Time.deltaTime);

        }

        else if (Vector3.Distance(transform.position, sheep.position) > stoppingDistance && Vector3.Distance(transform.position, sheep.position) > scurryDistance) //if near enough the stop distance it will stop moving
        {

            transform.position = this.transform.position;
        }

        else if (Vector3.Distance(transform.position, sheep.position) < scurryDistance) //back away
        {

            transform.position = Vector3.MoveTowards(transform.position, sheep.position, -speed * Time.deltaTime);

        }
        if (coolDownTimer < -0)
        {
            Instantiate(acorn, transform.position, Quaternion.identity);
            coolDownTimer = startCoolDownTimer;
        } else
        {
            coolDownTimer -= Time.deltaTime;
        }
      
    }
}
