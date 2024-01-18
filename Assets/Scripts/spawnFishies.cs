using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFishies : MonoBehaviour
{
    public GameObject[] Fishies;
    public int spawnMultiplier;
    public static GameObject[] staticFishies;
    private float basePercentage = 10f;
    private float difficulty = 2f;
    public float spawnRadius = 5f;
    private GameObject fish;
    private int amount = 1;
    public float[] percentages;
    public List<GameObject> activeFishies;
    private int rounds;
    public static int round = 1;

    // Start is called before the first frame update
    void Start()
    {
        calculateSpawnChances();
        randomizeFish();
        round = 1;
        rounds = 2;
        difficulty = 2;
    }

    private void Update()
    {
        
        if(rounds >= 5)
        {
            rounds = 0;
            difficulty++;
            calculateSpawnChances();
        }
    }

    private void calculateSpawnChances()
    {

        int totalFish = Fishies.Length;
       

        percentages = new float[totalFish];

        for (int i = 0; i < totalFish; i++)
        {
            percentages[i] = basePercentage * Mathf.Pow(difficulty/10f, i);
        }

        float sum = 0f;
        float multiplier = 0f;
        foreach (float value in percentages)
        {
            sum += value;
        }
        multiplier = 100 / sum;

        for (int i = 0; i < totalFish; i++)
        {
            percentages[i] *= multiplier;
        }
    }

    public void randomizeFish()
    {
        round++;
        rounds++;
        int random1 = Random.Range(0, 100);
        if (random1 < 60) { amount = 1 * spawnMultiplier;  }
        else if (random1 < 80) { amount = 2 * spawnMultiplier; }
        else if (random1 < 90) { amount = 3 * spawnMultiplier; }
        else if (random1 < 100) { amount = 4 * spawnMultiplier; }
        else { amount = 1; Debug.LogWarning("failed to randomize fish amount :("); }

        for (int i = 0; i < amount; i++)
        {
            int random2 = Random.Range(0, 100);
            float addedPercentage = 0;

            for (int r = 0; r < Fishies.Length; r++)
            {
                
                if (random2 < (percentages[r]+ addedPercentage)) 
                { 
                    fish = Fishies[r];
                    Vector3 pos = new Vector3
                    (   Random.Range(transform.position.x-spawnRadius, transform.position.x + spawnRadius),
                        Random.Range(transform.position.y - spawnRadius, transform.position.y + spawnRadius),
                        Random.Range(transform.position.z - spawnRadius, transform.position.z + spawnRadius));
                    
                    Instantiate(fish, pos, Quaternion.Euler(0f, 180f, 0f));
                    break;
                }
                else
                {
                    addedPercentage += percentages[r];
                }
            }

           
        }
    }

}
