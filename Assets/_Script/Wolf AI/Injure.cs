using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injure : WolfState
{

    public override void EnterState(WolfManager manager)
    {

    }

    public override void UpdateState(WolfManager manager)
    {
        #region ChooseTarget
        int random = Random.Range(0, manager.NearbySheep.Length);

        if (manager.NearbySheep.Length != 0)
        {
            manager.TargetSheep = manager.NearbySheep[random];
            Vector3 DirectionToSheep = (manager.TargetSheep.transform.position - manager.transform.position).normalized;

            //Following sheep
            manager.transform.position += DirectionToSheep * (Time.deltaTime * manager.StalkSpeed);
        }
        #endregion

        if (Vector3.Distance(manager.TargetSheep.transform.position, manager.transform.position) < 4)
        {
            manager.SwitchState(new FollowPath());
        }
    }
}
