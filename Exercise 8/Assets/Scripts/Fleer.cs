using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    public Agent fleeAgent;
    
    protected override void CalculateSteeringForces()
    {
        // flee away from other agent
        totalForce += Flee(fleeAgent.transform.position);
    }

    protected override void Update()
    {
        base.Update();

        if (CircleCollision(gameObject, fleeAgent))
        {
            Vector3 newPos = new Vector3(Random.Range(-7, 7), Random.Range(-4.5f, 4.5f), 0);

            transform.position = newPos;
        }
    }

    private bool CircleCollision(GameObject obj1, GameObject obj2)
    {
        SpriteRenderer r1 = obj1.GetComponent<SpriteRenderer>();
        SpriteRenderer r2 = obj2.GetComponent<SpriteRenderer>();
        
        float distance = Mathf.Pow((r1.bounds.center.x - r2.bounds.center.x), 2) + Mathf.Pow((r1.bounds.center.y - r2.bounds.center.y), 2);
        distance = Mathf.Sqrt(distance);

        if (distance < r1.bounds.extents.magnitude + r2.bounds.extents.magnitude)
        {
            return true;
        }

        return false;
    }
}
