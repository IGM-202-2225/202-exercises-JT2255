using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    public GameObject clockNum;
    private GameObject[] numbers;
    // Start is called before the first frame update
    void Start()
    {
        numbers = new GameObject[12];

        for (int i = 0; i < 360; i += 30)
        {
            Vector2 spawn;

            spawn.x = (2.3f * Mathf.Cos(i * Mathf.Deg2Rad));
            spawn.y = (2.3f * Mathf.Sin(i * Mathf.Deg2Rad));

            numbers[i/30] = Instantiate(clockNum, spawn, Quaternion.identity);
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i].GetComponent<TextMesh>().text = (15 - i).ToString();
        }

        numbers[0].GetComponent<TextMesh>().text = "3";
        numbers[1].GetComponent<TextMesh>().text = "2";
        numbers[2].GetComponent<TextMesh>().text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
