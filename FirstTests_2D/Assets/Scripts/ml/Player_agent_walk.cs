using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_agent_walk : Player_agent
{   

    public Transform target;

    public override void AgentReset()
    {
        base.AgentReset();

        TargetSpawner targetSpawner = target.GetComponent<TargetSpawner>();
        targetSpawner.Respawn();
    }
    public override void CollectObservations()
    {
        AddVectorObs(this.transform.localPosition.x);
        AddVectorObs(this.transform.localPosition.y);

        AddVectorObs(this.target.localPosition.x);
        AddVectorObs(this.target.localPosition.y);
    }
}
