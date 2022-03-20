using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public ParticleSystem BarkParticle;
    void Start()
    {
        BarkParticle = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BarkParticle.Play();
        }
    }
}
