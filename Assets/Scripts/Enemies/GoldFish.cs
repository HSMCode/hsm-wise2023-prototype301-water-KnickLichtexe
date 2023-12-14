using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFish : MonoBehaviour
{
    public bool Enemy = false;
    // Start is called before the first frame update
    void Start()
    {

        if(gameObject.transform.position.x >= 20)
        {
            Enemy = true;
        }
        if (Enemy == true)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Enemy == false)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
      if (Enemy == true)
        {
            transform.position += new Vector3(-1 * (Time.deltaTime * 2), 0, 0);
        }
        if (SwarmMovement.DestroySwarm && Enemy == true)
        {
            Destroy(gameObject);
        }

        if (SwarmMovement.DestroyPlayer && Enemy == false)
        {
            Destroy(gameObject);
        }
    }
}
