using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    public GameObject targetAgent;

    protected override void CalculateSteeringForces()
    {
        totalForce += Wander(2);
    }
}
