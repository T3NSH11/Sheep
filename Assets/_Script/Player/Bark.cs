using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public ParticleSystem BarkParticle;
    public GameObject BarkTrigger;
    public GameObject Barkinstance;
    public float TriggerSpeed;
    void Start()
    {
        BarkParticle = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BarkParticle.Play();
            Barkinstance = Instantiate(BarkTrigger, transform.position, transform.rotation);
        }
        Barkinstance.transform.position += transform.forward * TriggerSpeed * Time.deltaTime;

    }
}
