using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schoolingFish : MonoBehaviour
{
    public int strength = 1;
    public int foodSpawnChance;
    public float minSpeed, maxSpeed = 0.5f;
    private float speed;
    public float randomBehaviour = 5;
    float fishPersonalSpace = 1.5f;
    float rotationSpeed = 5f;
    private spawnFishies spawnFish;
    private playerFishies playerFishScript;
    public Vector3 enemyGoal, playerGoal;
    public int minCost, maxCost, cost;
    public bool isStarterFish = false;
    public bool isCannibal = false;
    public bool isCatfish = false;
    public bool isHungry = false;
    public bool isCroc = false;
    public static bool ANARCHY = false;
    public Animator animator;
    private bool isDead = false;
    

    // Start is called before the first frame update
    void Start()
    {
        ANARCHY = false;
        cost = Random.Range(minCost,maxCost + 1);
        fishPersonalSpace = 1.3f;
        rotationSpeed = 5f;
        speed = Random.Range(minSpeed, maxSpeed);

        spawnFish = GameObject.Find("Spawner").GetComponent<spawnFishies>();
        playerFishScript = GameObject.Find("Center").GetComponent<playerFishies>();

        if (isStarterFish)
        {
            playerFishScript.playerFish.Add(gameObject);
        }
        else
        {
            spawnFish.activeFishies.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyGoal = GameObject.Find("EnemyGoal").transform.position;
        playerGoal = GameObject.Find("Center").transform.position;
        
         if (ANARCHY && !isDead)
        {
            SEEYOUINVALHALLA();
        }
        else if (spawnFish.activeFishies.Contains(gameObject) && !isDead)
        {
            if (Random.Range(0, randomBehaviour) < 1)
            {
                ApplyEnemyRules();
            }

        }
        else if (playerFishScript.playerFish.Contains(gameObject) && !isDead)
        {
            if (Random.Range(0, randomBehaviour) < 1)
            {
                ApplyPlayerRules();
            }
        }
        else if (transform.position.y >= 7)
        {
             
                gameObject.SetActive(false);
            
        }

         if(!isDead)
        {
            transform.Translate(0, 0, Time.deltaTime * speed);

            Quaternion.Slerp
            (transform.rotation,
            new Quaternion(Quaternion.identity.x, transform.rotation.y, Quaternion.identity.z, Quaternion.identity.w),
            rotationSpeed * Time.deltaTime);
        }
         else
        {
            transform.Translate(0, Time.deltaTime * speed, 0);
        }
       

    }
    private void ApplyEnemyRules()
    {
        List<GameObject> activeFishies;
        activeFishies = spawnFish.activeFishies;

        Vector3 groupCenter = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float distance;

        int groupSize = 0;
        foreach (GameObject go in (activeFishies))
        {
            if(go != gameObject)
            {
                distance = Vector3.Distance(go.transform.position, this.gameObject.transform.position);

                if (distance < 3f)
                {
                    groupCenter += go.transform.position;
                    groupSize++;

                    if (distance < fishPersonalSpace)
                    {
                        avoid += this.transform.position - go.transform.position;
                    }
                    schoolingFish moreSchoolingFish = go.GetComponent<schoolingFish>();
                }
               
            }
            
        }

        Vector3 enemyDirection = Vector3.zero;

        if (groupSize > 0)
        {
            groupCenter = groupCenter / groupSize - transform.position;

            enemyDirection = (enemyGoal - transform.position + avoid) + groupCenter*0.5f;
        }
        else
        {
            enemyDirection = (enemyGoal - transform.position + avoid);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemyDirection), rotationSpeed * Time.deltaTime);

    }
    private void ApplyPlayerRules()
    {
        List<GameObject> activeFishies;
        activeFishies = spawnFish.activeFishies;

        Vector3 playerCenter = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float distance;

        foreach (GameObject go in (playerFishScript.playerFish))
        {
            distance = Vector3.Distance(go.transform.position, this.gameObject.transform.position);
            playerCenter += go.transform.position;
            if (distance < fishPersonalSpace)
            {
                avoid += this.transform.position - go.transform.position;
            }
            schoolingFish moreSchoolingFish = go.GetComponent<schoolingFish>();
        }

        playerCenter /= playerFishScript.playerFish.Count;

        Vector3 playerDirection = playerGoal - transform.position + avoid;

       
        if (playerDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDirection), rotationSpeed * Time.deltaTime);
        }

    }

    public void SEEYOUINVALHALLA()
    {

        bool isFighting = false;
        GameObject victim = null;
        float distance2;
        Vector3 avoid = Vector3.zero;


        // FISH IS ENEMY and isnt targeting a victim yet
        if (spawnFish.activeFishies.Contains(gameObject) && victim == null && playerFishies.isAlive )
        {
            // randomize a victim from the player's list
            victim = playerFishScript.playerFish[Random.Range(0, playerFishScript.playerFish.Count)];

            foreach (GameObject go in (spawnFish.activeFishies))
            {
                distance2 = Vector3.Distance(go.transform.position, this.gameObject.transform.position);
                if (distance2 < fishPersonalSpace)
                {
                    avoid += this.transform.position - go.transform.position;
                }
            }

            // for every fish in the players list
            for (int i = 0; i < playerFishScript.playerFish.Count; i++)
            {   
                // calculate the distance
                float distance = Vector3.Distance(victim.transform.position, transform.position);

                // if the distance to the players fish is smaller than 1 and this fish isnt fighting already
                if (distance < 1 && !isFighting )
                {
                    // now this fish is fighting
                    isFighting = true;

                    // get the strength of the victim
                    schoolingFish victimScript = victim.GetComponent<schoolingFish>();
                    int victimStrength = victimScript.strength;

                    // if this fish defeats its victim
                    if (Random.Range(0,100) <= strength * (100/(strength + victimStrength)))
                    {
                        // unalive the victim
                        victimScript.death();
                        playerFishScript.playerFish.Remove(victim);


                        // check if the player is still alive after loosing this fish
                        if (playerFishScript.playerFish.Count == 0)
                        {
                            playerFishies.isAlive = false;
                        }
                        return;
                    }

                    // if this fish dies in battle
                    else
                    {
                        // send this fish to Valhalla
                        // but give the player food before that
                        if( isCannibal)
                        {
                            playerFishScript.food += cost;
                        }
                        
                        death();

                        
                        //spawnFish.activeFishies.Remove(gameObject);
                    }
                }
            }
        }

        // FISH IS FRIEND and isnt targeting a victim yet
        else if (playerFishScript.playerFish.Contains(gameObject) && victim == null  && ANARCHY && spawnFish.activeFishies.Count != 0)
        {
            foreach (GameObject go in (playerFishScript.playerFish))
            {
                distance2 = Vector3.Distance(go.transform.position, this.gameObject.transform.position);
                if (distance2 < fishPersonalSpace)
                {
                    avoid += this.transform.position - go.transform.position;
                }
            }
            // randomize a victim from the player's list
            victim = spawnFish.activeFishies[Random.Range(0, spawnFish.activeFishies.Count)];
        }

        if (ANARCHY && victim != null)
        {
            Vector3 playerDirection = victim.transform.position - transform.position + avoid;

            if (playerDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDirection), rotationSpeed * Time.deltaTime);
            }
        }

    }
    private void death()
    {
        isDead = true;
        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        animator.SetBool("isAlive", false);
        spawnFish.activeFishies.Remove(gameObject);
        speed = 1.5f;
    }
}
