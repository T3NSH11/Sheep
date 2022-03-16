using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : WolfState
{
    public AIPath currentPath = GameObject.FindGameObjectWithTag("WolfPath").GetComponent<AIPath>(); // Path AI follows
    public int currentNodeID = 0;
    public float Speed = 5f;
    public float RotationSpeed = 5f;
    public float WayPointSize = 1f;
    float testtimer;

    public override void EnterState(WolfManager manager)
    {
       
    }
    public override void UpdateState(WolfManager manager)
    {
       float node_Distance = Vector3.Distance(currentPath.pathNodes[currentNodeID].position, manager.AI.position);
       manager.AI.position = Vector3.MoveTowards(manager.AI.position, currentPath.pathNodes[currentNodeID].position, Time.deltaTime * Speed);

       var object_Rotation = Quaternion.LookRotation(currentPath.pathNodes[currentNodeID].position - manager.AI.position);
       manager.AI.rotation = Quaternion.Slerp(manager.AI.rotation, object_Rotation, Time.deltaTime * RotationSpeed);

        if (node_Distance <= WayPointSize)
        {
            currentNodeID++;
        }

        if (currentNodeID >= currentPath.pathNodes.Count)
        {
            currentNodeID = 0;
        }

        testtimer += Time.deltaTime;
        if (testtimer > 4)
        {
           // manager._followpath = this;
            manager.SwitchState(new Injure());
        }
    }
}
