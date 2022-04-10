using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelFollowPath : SquirrelBaseState
{
    public AIPath currentPath = GameObject.FindGameObjectWithTag("SquirrelPath").GetComponent<AIPath>(); // Path AI follows
    public int currentNodeID = 0;
    public float Speed = 5f;
    public float WayPointSize = 1f;
    float testtimer;




    public override void EnterState(SquirrelManager squirrel)
    {

    }

    public override void UpdateState(SquirrelManager squirrel)
    {
        float node_Distance = Vector3.Distance(currentPath.pathNodes[currentNodeID].position, squirrel.gameObject.transform.position);
        squirrel.gameObject.transform.position = Vector3.MoveTowards(squirrel.gameObject.transform.position, currentPath.pathNodes[currentNodeID].position, Time.deltaTime * Speed);

        if (node_Distance <= WayPointSize)
        {
            currentNodeID++;
        }

        if (currentNodeID >= currentPath.pathNodes.Count)
        {
            currentNodeID = 0;
        }

        if (squirrel.NearbySheep.Length != 0)
        {
            squirrel.switchState(squirrel.SeekAndAvoid);
        }
    }

    public override void OncollisionEnter(SquirrelManager squirrel)
    {

    }



}
