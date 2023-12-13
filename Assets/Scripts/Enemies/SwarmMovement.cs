using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    public GameObject ClownFish;
    public GameObject CatFish;
    public GameObject GoldFish;

    public int RF = 0;
    public int RV = 0;
    public static int ECL = 0;
    public static int ECT = 0;
    public static int EGD = 0;


    // Start is called before the first frame update
    void Start()
    {
        RV = Random.Range(1, 6);
        gameObject.AddComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (RV > 0)
        {
            RF = Random.Range(1, 4);
            RV -= 1;


            if (RF == 1)
            {
                Instantiate(ClownFish, new Vector3(Random.Range(29f, 31f), Random.Range(.5f, 1.5f), Random.Range(-1f, 1f)),  Quaternion.identity);
                
            }

            if (RF == 2)
            {
                Instantiate(CatFish, new Vector3(Random.Range(29f, 31f), Random.Range(.5f, 1.5f), Random.Range(-1f, 1f)), Quaternion.identity);
            }

            if (RF == 3)
            {
                Instantiate(GoldFish, new Vector3(Random.Range(29f, 31f), Random.Range(.5f, 1.5f), Random.Range(-1f, 1f)), Quaternion.identity);
            }

            RF = 0;
        }

        

        transform.position += new Vector3(-1*(Time.deltaTime*2), 0, 0);
    }
}
