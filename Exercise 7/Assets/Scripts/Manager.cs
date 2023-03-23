using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    public List<GameObject> monsters;

    public Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = transform.position.z;

        foreach (GameObject monster in monsters)
        {
            monster.GetComponent<PhysicsObject>().ApplyForce(mousePos - monster.transform.position);
        }
    }
}
