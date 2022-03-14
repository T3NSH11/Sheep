using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPath : WolfState
{
    public override void EnterState(WolfManager manager)
    {
        
    }
    public override void UpdateState(WolfManager manager)
    {
        Vector3 direction = (manager.transform.position - manager.player.transform.position).normalized;

        manager.rb.velocity = direction * manager.speed;
    }
}
