using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<SpriteRenderer> creatures = new List<SpriteRenderer>();

    private int numCreatures = 0;
    public int minCreatures = 10;
    public int maxCreatures = 50;

    public SpriteRenderer elephant;
    public SpriteRenderer turtle;
    public SpriteRenderer snail;
    public SpriteRenderer octopus;
    public SpriteRenderer kangaroo;

    private Vector3 minPosition;
    private Vector3 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        Spawn();
    }

    //generate new creatures randomly
    public void Spawn()
    {
        CleanUp();

        numCreatures = Random.Range(minCreatures, maxCreatures);

        for (int i = 0; i < numCreatures; i++)
        {
            creatures.Add(SpawnCreature());
        }    
    }

    //choose random creature
    private SpriteRenderer ChooseRandomCreature() 
    {
        float randChance = Random.Range(0.0f, 1.0f);

        if (randChance < 0.25)
        { 
            return elephant;  
        }
        else if (randChance < 0.45)
        { 
            return turtle; 
        }
        else if (randChance < 0.6)
        { 
            return snail; 
        }
        else if (randChance < 0.7)
        {
            return octopus; 
        }
        else 
        { 
            return kangaroo;
        }
    }   

    //spawn creature at random creature
    private SpriteRenderer SpawnCreature() 
    {
        Vector3 spawnPosition = new Vector3(Gaussian(0, 9/4), Gaussian(0, 5/4), 0f);

        SpriteRenderer spawnedCreature = Instantiate(ChooseRandomCreature(), spawnPosition, Quaternion.identity);
        spawnedCreature.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

        return spawnedCreature;
    }

    //delete old creatures when spawning new ones
    private void CleanUp()
    {
        foreach (SpriteRenderer creature in creatures)
        {
            Destroy(creature.gameObject);
        }

        creatures.Clear();
    }

    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }
}
