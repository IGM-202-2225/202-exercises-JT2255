using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsObject))]
public abstract class Agent : MonoBehaviour
{
    public PhysicsObject physicsObject;

    public float maxSpeed = 5f;
    public float maxForce = 5f;

    protected Vector3 totalForce = Vector3.zero;
    
    private void Awake () 
    {
        if (physicsObject == null)
        {
            physicsObject = GetComponent<PhysicsObject>();
        }
    }

    protected virtual void Update()
    {
        CalculateSteeringForces();

        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        physicsObject.ApplyForce(totalForce);

        totalForce = Vector3.zero;
    }

    protected abstract void CalculateSteeringForces();

    protected Vector3 Seek(Vector3 targetPos, float weight = 1f)
    {
        // calculate desired velocity
        Vector3 desiredVelocity = targetPos - physicsObject.Position;

        // set desired velocity magnitude to max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;

        return seekingForce * weight;
        // apply seek steering force
        //totalForce += seekingForce * weight;
    }

    protected Vector3 Flee(Vector3 targetPos, float weight = 1f)
    {
        // calculate desired velocity
        Vector3 desiredVelocity = physicsObject.Position - targetPos;
    
        // set desired velocity magnitude to max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // calculate the flee steering force
        Vector3 fleeingForce = desiredVelocity - physicsObject.Velocity;
        
        return fleeingForce * weight;
        // apply the flee steering force
        //totalForce += fleeingForce * weight;
    }

    protected Vector3 Pursue(Agent target)
    {
        return Seek(target.CalculateFuturePosition(2f));
    }

    protected Vector3 Wander(float time)
    {
        Vector3 circleCenter;
        circleCenter = physicsObject.Velocity;
        circleCenter.Normalize();
        circleCenter.Scale(new Vector3(1.5f, 1.5f, 1.5f));

        
      

        return Vector3.zero;
    }

    public Vector3 CalculateFuturePosition(float time)
    {
        return transform.position + (physicsObject.Velocity * time);
    }
}
