using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    private spawnFishies spawnFish;
    private playerFishies playerFishScript;
    Vector3 bubblePos;
    public TextMeshProUGUI foodCost;
    public TextMeshProUGUI food;
    public TextMeshProUGUI score;


    // Start is called before the first frame update
    void Start()
    {
        spawnFish = GameObject.Find("Spawner").GetComponent<spawnFishies>();
        playerFishScript = GameObject.Find("Center").GetComponent<playerFishies>();
    }

    // Update is called once per frame
    void Update()
    {
        foodCost.text = playerFishScript.foodCost.ToString();
        food.text = ("Food: ") + playerFishScript.food.ToString();
        score.text = ("Power: ") + playerFishScript.highscore.ToString();
        moveBubble();
       
    }

    void moveBubble()
    {
        bubblePos = Vector3.zero;
        foreach (GameObject go in (spawnFish.activeFishies))
        {
            bubblePos += go.transform.position;
        }
        if (spawnFish.activeFishies.Count != 0)
        {
            bubblePos /= spawnFish.activeFishies.Count;
            transform.position = bubblePos;
        }
    }
}
