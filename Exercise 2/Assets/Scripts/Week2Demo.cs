using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    [SerializeField]
    //int health = 5;

    public GameObject snowman;


    // Start is called before the first frame update
    void Start()
    {
       /* for (int i = 0; i < health; i++)
        {
            Instantiate(snowman, new Vector3(0, i, 0), new Quaternion());
        }
       */
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Mathf.PingPong(Time.time*1.5f, 4.02f), transform.position.y, transform.position.z);

        if (gameObject.transform.position.x >= 4){
            Instantiate(snowman, new Vector3(Random.Range(-22f, 22f), Random.Range(0, 4f), Random.Range(-15f, 20f)), new Quaternion());
        }
    } 
}
