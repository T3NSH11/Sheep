using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public ParticleSystem BarkParticle;
    public GameObject BarkTrigger;
    public GameObject Barkinstance;
    public float TriggerSpeed;
    float triggertimer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindGameObjectWithTag("BarkTrigger") == null)
        {
            BarkParticle.Play();
            Barkinstance = Instantiate(BarkTrigger, transform.position, Quaternion.identity);
        }

        if (triggertimer > 2.2f)
        {
            Destroy(Barkinstance);
            triggertimer = 0;
        }
        else
        {
            triggertimer += Time.deltaTime;
        }
        if(Barkinstance != null) 
        {
            Barkinstance.transform.position += transform.right * TriggerSpeed * Time.deltaTime;
        }
        
    }
}
