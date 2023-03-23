using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsObject : MonoBehaviour
{
    Vector3 position = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    Vector3 acceleration = Vector3.zero;

    [SerializeField]
    float mass = 1f;

    public bool useGravity, useFriction;
    public float frictionCoeff;

    public Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (useGravity)
        {
            ApplyGravity(Vector3.down);
        }

        if (useFriction)
        {
            ApplyFriction(frictionCoeff);
        }

        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;

        //Do checks on new position here

        CheckForBounce();

        transform.position = position;

        acceleration = Vector3.zero;
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    void ApplyFriction(float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coeff;

        ApplyForce(friction);
    }

    void ApplyGravity(Vector3 force)
    {
        acceleration += force;
    }

    void CheckForBounce()
    {
          if (position.x > 8)
          {
              velocity.x *= -1f;
          }
          else if (position.x < -8)
          {
              velocity.x *= -1f;
          }

          if (position.y > 5)
          {
              velocity.y *= -1f;
          }
          else if (position.y < -5)
          {
              velocity.y *= -1f;
          }
         
    }
}
