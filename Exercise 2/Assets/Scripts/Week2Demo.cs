using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    [SerializeField]
    int health = 5;

    public GameObject snowman;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < health; i++)
        {
            Instantiate(snowman, new Vector3(0, i, 0), new Quaternion());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.0005f, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    
}
