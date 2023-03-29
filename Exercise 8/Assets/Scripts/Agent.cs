using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsObject))]
public abstract class Agent : MonoBehaviour
{
    public PhysicsObject physicsObject;

    public float maxSpeed = 5f;
    public float maxForce = 5f;

    private Vector3 totalForce = Vector3.zero;
    
    private void Awake () 
    {
        if (physicsObject == null)
        {
            physicsObject = GetComponent<PhysicsObject>();
        }
    }

    void Update()
    {
        CalculateSteeringForces();

        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        physicsObject.ApplyForce(totalForce);

        totalForce = Vector3.zero;
    }

    protected abstract void CalculateSteeringForces();

    protected void Seek(Vector3 targetPos, float weight = 1f)
    {
        // calculate desired velocity
        Vector3 desiredVelocity = targetPos - physicsObject.Position;

        // set desired velocity magnitude to max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;

        // apply seek steering force
        totalForce += seekingForce * weight;
    }

    protected void Flee(Vector3 targetPos, float weight = 1f)
    {
        // calculate desired velocty
        Vector3 desiredVelocity = physicsObject.Position - targetPos;
    }
}
