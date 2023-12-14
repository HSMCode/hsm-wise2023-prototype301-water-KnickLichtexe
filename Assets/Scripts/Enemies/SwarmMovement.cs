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
    public  int ECL = 0;
    public  int ECT = 0;
    public  int EGD = 0;
    public static bool DestroySwarm = false;
    public static bool DestroyPlayer = false;


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
                ECL += 1;
                
            }

            if (RF == 2)
            {
                Instantiate(CatFish, new Vector3(Random.Range(29f, 31f), Random.Range(.5f, 1.5f), Random.Range(-1f, 1f)), Quaternion.identity);
                ECT += 1;
            }

            if (RF == 3)
            {
                Instantiate(GoldFish, new Vector3(Random.Range(29f, 31f), Random.Range(.5f, 1.5f), Random.Range(-1f, 1f)), Quaternion.identity);
                EGD += 1;
            }

            RF = 0;
        }

        

        transform.position += new Vector3(-1*(Time.deltaTime*2), 0, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey("space") && other.gameObject.tag == "EnemySwarm")
        {
            PlayerControls.Food = PlayerControls.Food - (ECL + ECT + EGD);

            if (ECL >= 1)
            {
                Instantiate(ClownFish, new Vector3(Random.Range(-5f, -3f), Random.Range(1f, 3f), Random.Range(-1f, 1f)), Quaternion.identity);
                ECL -= 1;
            }

            if (ECT >= 1)
            {
                Instantiate(CatFish, new Vector3(Random.Range(-5f, -3f), Random.Range(1f, 3f), Random.Range(-1f, 1f)), Quaternion.identity);
                ECT -= 1;
            }

            if (EGD >= 1)
            {
                Instantiate(GoldFish, new Vector3(Random.Range(-5f, -3f), Random.Range(1f, 3f), Random.Range(-1f, 1f)), Quaternion.identity);
                EGD -= 1;
            }

            if(ECL + ECT + EGD ==0)
            {
                DestroySwarm = true;
                DestroySwarm = false;
                Destroy(gameObject);
            }
            else if (Input.GetKey("space") && other.gameObject.tag == "EnemySwarm" && ECL + ECT + EGD < PlayerControls.Food)
            {
                DestroyPlayer = true;
            }
        }
    }
        void OnTriggerExit(Collider other)
        {
            if (PlayerControls.FG >= (ECL + ECT + EGD) && other.gameObject.tag == "EnemySwarm")
            {
                PlayerControls.Food += ECL + ECT + EGD;
                DestroySwarm = true;
                DestroySwarm = false;
                Destroy(gameObject);
            }
            else if (PlayerControls.FG <= (ECL + ECT + EGD) && other.gameObject.tag == "EnemySwarm")
            {
                Debug.Log("You loose");
            }
        }
}
