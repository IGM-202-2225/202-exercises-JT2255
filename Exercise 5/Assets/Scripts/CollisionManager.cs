using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject player;
    public GameObject text;

    bool isAABB = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAABB)
        {
            text.GetComponent<TextMesh>().text = "Current Control Method: AABB";

            if (AABBCollision(player, obstacle1))
            {
                obstacle1.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                obstacle1.GetComponent<SpriteRenderer>().color = Color.white;
            }

            if (AABBCollision(player, obstacle2))
            {
                obstacle2.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                obstacle2.GetComponent<SpriteRenderer>().color = Color.white;
            }

            if (AABBCollision(player, obstacle3))
            {
                obstacle3.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                obstacle3.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else
        {
            text.GetComponent<TextMesh>().text = "Current Control Method: Bounding Circle";

            if (CircleCollision(player, obstacle1))
            {
                obstacle1.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                obstacle1.GetComponent<SpriteRenderer>().color = Color.white;
            }

            if (CircleCollision(player, obstacle2))
            {
                obstacle2.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                obstacle2.GetComponent<SpriteRenderer>().color = Color.white;
            }

            if (CircleCollision(player, obstacle3))
            {
                obstacle3.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                obstacle3.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }      
    }

    bool AABBCollision(GameObject obj1, GameObject obj2)
    {
        SpriteRenderer r1 = obj1.GetComponent<SpriteRenderer>();
        SpriteRenderer r2 = obj2.GetComponent<SpriteRenderer>();

        if (r2.bounds.min.x < r1.bounds.max.x && 
            r2.bounds.max.x > r1.bounds.min.x &&
            r2.bounds.max.y > r1.bounds.min.y &&
            r2.bounds.min.y < r1.bounds.max.y)
        {
            return true;
        }

        return false;
    }

    bool CircleCollision(GameObject obj1, GameObject obj2)
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

    public void OnSpacePress(InputAction.CallbackContext context)
    {
        if (isAABB)
        {
            isAABB = false;
        }
        else
        {
            isAABB = true;
        }
    }
}
