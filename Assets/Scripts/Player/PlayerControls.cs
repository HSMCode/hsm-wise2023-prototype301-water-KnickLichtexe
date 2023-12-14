using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    public GameObject ClownFish;
    public GameObject CatFish;
    public GameObject GoldFish;
    public TextMeshPro Counter;

    public string counter;

    public int FS = 0; //Fish Spawn
    public static int FG = 0; //Fish Group
    public int CL = 0; //Clown
    public int CT = 0; //Cat
    public int GD = 0; //Gold
    public static int Food = 10;
    public float s = 0;

    // Start is called before the first frame update
    void Start()
    {
        FS = Random.Range (1, 4);
        if (FS == 1)
        {
            Instantiate(ClownFish, new Vector3(-4, 2, 0), Quaternion.identity);
            CL += 3;
             
        }

        if (FS == 2)
        {
            Instantiate(CatFish, new Vector3(-4, 2, 0), Quaternion.identity);
            CT += 1;
        }

        if (FS == 3)
        {
            Instantiate(GoldFish, new Vector3(-4, 2, 0), Quaternion.identity);
            GD += 2;
        }

        if (Food<=-1)
        {
            Debug.Log("You loose");
        }

        FS = 0;
        counter = "";
        counter = counter + Food;
        Counter.text = counter;
    }

    // Update is called once per frame
    void Update()
    {
        FG = CL + CT + GD;
        s = s + Time.deltaTime;

        if (s>=5f)
        {
            Food += CT;
            s = 0;
        }
        counter = "";
        counter = counter + Food;
        Counter.text = counter;

        if (SwarmMovement.DestroyPlayer)
        {
            Destroy(gameObject);
        }
    }


}
