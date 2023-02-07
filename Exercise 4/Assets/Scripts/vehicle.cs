using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicle : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector3 direction = Vector3.right;
    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Vector3 vehiclePosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        vehiclePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        vehiclePosition += velocity;
        transform.position = vehiclePosition;
    }
}
