using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    Vector3 position = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    Vector3 acceleration = Vector3.zero;

    [SerializeField]
    float mass = 1f;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;

        //Do checks on new position here

        transform.position = position;

        acceleration = Vector3.zero;
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }
}
