using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PlayerFish;
    public GameObject EnemieSpawner;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PlayerFish, new Vector3(-4, 2, -1), Quaternion.identity);
        Instantiate(EnemieSpawner, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
