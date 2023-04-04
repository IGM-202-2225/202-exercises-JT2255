using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public Agent targetAgent;
    
    protected override void CalculateSteeringForces()
    {
       // move towards other agent
       totalForce += Seek(targetAgent.transform.position);
    }
}
