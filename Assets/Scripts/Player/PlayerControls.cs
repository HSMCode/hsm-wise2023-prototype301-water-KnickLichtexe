using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject ClownFish;
    public GameObject CatFish;
    public GameObject GoldFish; 

    public int FS = 0; //Fish Spawn
    public int FG = 0; //Fish Group
    public int CL = 0; //Clown
    public int CT = 0; //Cat
    public int GD = 0; //Gold
    public int Food = 10;

    // Start is called before the first frame update
    void Start()
    {
        FS = Random.Range (1, 4);
        if (FS == 1)
        {
            Instantiate(ClownFish, new Vector3(-4, 2, -1), Quaternion.identity);
            CL += 1;
        }

        if (FS == 2)
        {
            Instantiate(CatFish, new Vector3(-4, 2, -1), Quaternion.identity);
            CT += 1;
        }

        if (FS == 3)
        {
            Instantiate(GoldFish, new Vector3(-4, 2, -1), Quaternion.identity);
            GD += 1;
        }

        FS = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FG = CL + CT + GD;
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "EnemySwarm" && Input.GetKeyUp("space"))
        {
            SwarmMovement.ECL = 2;
        }
       else
        {

        }

    }
}
