using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedLogic : MonoBehaviour
{


    // get NPC to call move methods
    private GameObject[] npcs;
    private NPCMovement NPCMovementScript;

    // get all Allys
    private GameObject[] allys;
    private NPCMovement AllyMovementScript;

    // get Spawner
    private GameObject spawner;
    private NPCSpawner NPCSpawnerScript;
    

    public float DecisionTime = 5f;

    void Start() {    

    }

    void Update() {

        // Get all NPC's and Allys Gameobjects and their scripts in update because of the new NPCs spawning and Tag Changes
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        allys = GameObject.FindGameObjectsWithTag("Ally");

        // get spawner for spawn triggering
        spawner = GameObject.FindWithTag("Spawner");
        NPCSpawnerScript = spawner.GetComponent<NPCSpawner>();
        
        // once fish reaches spot start timer
        for(int i=1; i < npcs.Length; i++){
            NPCMovementScript = npcs[i].GetComponent<NPCMovement>();
            if (NPCMovementScript.waitPointReached == true){
                StartCoroutine(Wait(DecisionTime));
            }
        }

        // if player feeds move fish to player and rotate
        if ( this.GetComponent<KeyboardInput>().Feed() == true){

            // Stop Coroutine
            StopCoroutine(Wait(DecisionTime));

            // Add Velocity to all NPC's, Rotate and give new Tag
            for(int i=1; i < npcs.Length; i++){
                NPCMovementScript = npcs[i].GetComponent<NPCMovement>();
                NPCMovementScript.NPCMove(NPCMovementScript.movementSpeedVector);
                NPCMovementScript.RotateNPC(180f);
                npcs[i].tag = "Ally";
                NPCMovementScript.newAllyMoves = true;
            }

            // once Ally reached Swarm, Spawn new Fish
            // for(int i=1; i < allys.Length; i++){
            //     AllyMovementScript = allys[i].GetComponent<NPCMovement>();
            //     if (AllyMovementScript.newAllyMoves == false){
            //         // Spawn new Fish
            //         NPCSpawnerScript.InstanceOfNPCSpawn();
            //     }
            // }

        }

    }

    // wait for x amount of seconds, then move NPC
    IEnumerator Wait(float seconds){

        yield return new WaitForSecondsRealtime(seconds);

        // Add Velocity to all NPC's
        for(int i=1; i < npcs.Length; i++){
            NPCMovementScript = npcs[i].GetComponent<NPCMovement>();
            NPCMovementScript.NPCMove(NPCMovementScript.movementSpeedVector);
        }

    }

}
/*
    TODO: Add Failsave to only be able to press jump when NPC is in wait position
*/