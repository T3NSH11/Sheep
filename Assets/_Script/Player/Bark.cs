using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public ParticleSystem BarkParticle;
    public GameObject Player;
    public GameObject BarkTrigger;
    public GameObject Barkinstance;
    public float TriggerSpeed;
    float triggertimer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindGameObjectWithTag("BarkTrigger") == null)
        {
            BarkParticle.Play();
            Barkinstance = Instantiate(BarkTrigger, transform.position, Player.transform.rotation);
        }

        if (triggertimer > 2.85f)
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
            Barkinstance.transform.position += Player.transform.forward * TriggerSpeed * Time.deltaTime;
        }
        
    }
}
