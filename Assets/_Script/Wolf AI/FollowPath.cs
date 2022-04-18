using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : WolfState
{
    public AIPath currentPath = GameObject.FindGameObjectWithTag("WolfPath").GetComponent<AIPath>(); // Path AI follows
    public int currentNodeID = 0;
    public float Speed = 5f;
    public float WayPointSize = 1f;
    float Timeouttimer;

    public override void EnterState(WolfManager manager)
    {
       
    }
    public override void UpdateState(WolfManager manager)
    {
       float node_Distance = Vector3.Distance(currentPath.pathNodes[currentNodeID].position, manager.AI.position);
       manager.AI.position = Vector3.MoveTowards(manager.AI.position, currentPath.pathNodes[currentNodeID].position, Time.deltaTime * Speed);
       Vector3 LookTowardsRotation = (currentPath.pathNodes[currentNodeID].transform.position - manager.transform.position).normalized;
       LookTowardsRotation.y = 0f;
       manager.transform.rotation = Quaternion.RotateTowards(manager.transform.rotation, Quaternion.LookRotation(LookTowardsRotation), Time.deltaTime * manager.RotationSpeed);

        if (node_Distance <= WayPointSize)
        {
            currentNodeID++;
        }

        if (currentNodeID >= currentPath.pathNodes.Count)
        {
            currentNodeID = 0;
        }

        Timeouttimer += Time.deltaTime;

        if (manager.NearbySheep.Length != 0 && Timeouttimer >= 15)
        {
            Timeouttimer = 0;
            manager.SwitchState(new Injure());
        }
    }
}
