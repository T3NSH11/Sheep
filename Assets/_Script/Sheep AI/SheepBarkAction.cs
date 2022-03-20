using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBarkAction : SheepState
{
    ParticleSystem m_ParticleSystem;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    Rigidbody AiRb;
    Vector3 AiPos;
    float MoveSpeed = 5;
    public override void EnterState(SheepManager manager)
    {
        AiRb = manager.AiRb;
        AiPos = manager.AI.position;
    }

    public override void UpdateState(SheepManager manager)
    {

    }

    void OnParticleTrigger()
    {
        int numEnter = m_ParticleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        Vector3 ParticlePos = enter[0].position;
        AiRb.velocity = (ParticlePos - AiPos).normalized * MoveSpeed;
    }
}
