using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseSeeker : Agent
{
    protected override void CalculateSteeringForces()
    {
        // Seek towards mouse position
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0f;
        
        Seek(mousePos);
        
    }
}
