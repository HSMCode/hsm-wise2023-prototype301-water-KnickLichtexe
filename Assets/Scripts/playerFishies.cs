using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerFishies : MonoBehaviour
{
    public static bool isAlive = true;
    float holdTime = 0.6f;
    spawnFishies spawnFish;
    public GameObject spawner;
    public List<GameObject> playerFish;
    public int score = 0, highscore = 0, finalScore = 0;
    public int food = 5;
    public int foodCost;
    public int catfishChance = 15;
    public GameObject sardine;
    public GameObject bubble;
    public GameObject catfishedPanel;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI gameOverFinalScore;

    private float t = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnFish = spawner.GetComponent<spawnFishies>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        finalScore = highscore + spawnFishies.round -1;
        calculateScore();
        if (Input.GetButtonDown("Jump") && !isAlive)
        {
            SceneManager.LoadScene("SwarmFish");
        }

        if (playerFish.Count == 0)
        {
            isAlive = false;
        }

        if (!isAlive)
        {
            gameOverFinalScore.text = "Score: " + finalScore;
            gameOverScore.text = "Your swarm reached a power of " + highscore.ToString() + " and survived " + (spawnFishies.round - 1) + " rounds.";
            gameOverScreen.SetActive(true);
        }

        if (score > highscore)
        {
            highscore = score;
        }
        calculateFoodCost();

        if (spawnFish.activeFishies.Count == 0 && isAlive)
        {
            AddFood();
            schoolingFish.ANARCHY = false;
            spawnFish.randomizeFish();
            Invoke(("setBubbleActive"), 0.02f);
        }

        if (Input.GetButtonDown("Jump") && !schoolingFish.ANARCHY && isAlive)
        {
            t = 0f;
        }
        if (Input.GetButton("Jump") && spawnFish.activeFishies.Count != 0 && !schoolingFish.ANARCHY && isAlive)
        {
            t += Time.deltaTime;
            if (t >= holdTime)
            {
                bubble.SetActive(false);
                schoolingFish.ANARCHY = true;
            }
        }
        if (Input.GetButtonUp("Jump") && !schoolingFish.ANARCHY && isAlive)
        {
            if( t < holdTime && food >= foodCost)
            {
                RemoveFood();
                AddFood();

                for (int i = 0; i < spawnFish.activeFishies.Count; i++)
                {
                    schoolingFish moreSchoolingFish = spawnFish.activeFishies[i].GetComponent<schoolingFish>();

                    if (moreSchoolingFish.isCatfish && Random.Range(0,100) < catfishChance)
                    {
                        GameObject catfish;
                        catfish = spawnFish.activeFishies[i];
                        catfishedPanel.SetActive(true);
                        Vector3 position = catfish.transform.position;
                        Quaternion rotation = catfish.transform.rotation;
                        spawnFish.activeFishies.RemoveAt(i);
                        Destroy(catfish);
                        Instantiate(sardine, position, rotation);
                        playerFish.Add(sardine);
                    }
                    else
                    {
                        playerFish.Add(spawnFish.activeFishies[i]);
                    }
                }
                spawnFish.activeFishies.Clear();
                
                spawnFish.randomizeFish();
            }

        }
    }

    private void OnApplicationQuit()
    {
        spawnFish.activeFishies.Clear();
        playerFish.Clear();

    }

    private void calculateScore()
    {
        score = 0;
        foreach (GameObject go in (playerFish))
        {
            schoolingFish moreSchoolingFish = go.GetComponent<schoolingFish>();
            score += moreSchoolingFish.strength;
        }
    }

    private void calculateFoodCost()
    {
        foodCost = 0;
        foreach (GameObject go in (spawnFish.activeFishies))
        {
            schoolingFish moreSchoolingFish = go.GetComponent<schoolingFish>();
            foodCost += moreSchoolingFish.cost;
        }
    }

    private void AddFood()
    {
        foreach (GameObject go in (playerFish))
        {
            schoolingFish moreSchoolingFish = go.GetComponent<schoolingFish>();
            if (moreSchoolingFish.isHungry)
            {
                GameObject victim = playerFish[Random.Range(0, playerFish.Count)];
                while (victim == go || moreSchoolingFish.isCroc)
                {
                    victim = playerFish[Random.Range(0, playerFish.Count)];
                }


            }
            
            if (moreSchoolingFish.foodSpawnChance > Random.Range(0,100))
            {
                food += 1;
                ParticleSystem particleSystem = moreSchoolingFish.transform.GetChild(1).GetComponent<ParticleSystem>();
                particleSystem.Emit(1);
            }
            
        }
    }

    private void RemoveFood()
    {
        food -= foodCost;
    }

    private void setBubbleActive()
    {
        bubble.SetActive(true);
    }
}
