using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public GameObject targetAgent;
    
    protected override void CalculateSteeringForces()
    {
        // move towards other agent
        Seek(targetAgent.transform.position);
    }
}
