using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class vehicle : MonoBehaviour
{
    [SerializeField]
    float speed, turnAmount;

    Vector3 direction = Vector3.zero;
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

        //wrap here
        if (vehiclePosition.x > 9)
        {
            vehiclePosition.x = -9;
        }

        if (vehiclePosition.x < -9)
        {
            vehiclePosition.x = 9;
        }


        transform.position = vehiclePosition;    

     //   transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), 0.005f);
    }

    public void OnPlayerMove(InputAction.CallbackContext context)
    {   
        direction = context.ReadValue<Vector2>();

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward,direction);
        }
    }
}
