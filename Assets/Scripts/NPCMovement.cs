using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    private GameObject NPCWait;
    private GameObject NPCWaitSwarm;
    private Vector3 NPCposition;
    private NPCWait NPCWaitSript;
    private float SpawnerToWaitOffset;
    private NPCSpawner spawnerScript;
    private Rigidbody NPCRigidbody;
    [HideInInspector]
    public Vector3 movementSpeedVector = new Vector3(0, 0, 0);
    public bool waitPointReached = false;
    public bool newAllyMoves = false;

    public float MovementSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {
        // get own position
        NPCposition = this.transform.position;

        // get offset of wait point
        NPCWait = GameObject.FindWithTag("NPCWait");
        NPCWaitSript = NPCWait.GetComponent<NPCWait>();

        // get offset of swarm wait point
        NPCWaitSwarm = GameObject.FindWithTag("NPCWaitSwarm");

        SpawnerToWaitOffset = NPCWaitSript.WaitOffset();

        // calculate hold position
        NPCposition.x = NPCposition.x + SpawnerToWaitOffset;

        // move NPC

        // get the script that spawns NPCs
        spawnerScript = GameObject.FindWithTag("Spawner").GetComponent<NPCSpawner>();
        // get the rigidbody of the exact instance that just got spawned
        NPCRigidbody = spawnerScript.NPCInstances[spawnerScript.randomValue].GetComponent<Rigidbody>();

        // convert movementspeed
        movementSpeedVector.x = -MovementSpeed;

        // Add a Force to the Rigidbody
        NPCMove(movementSpeedVector);

    }

    // Update is called once per frame
    void Update()
    {
        // move towards X until wait for decision position arrived
        if (this.transform.position.x < NPCWait.transform.position.x && waitPointReached == false){
            //NPCRigidbody.AddForce(-movementSpeedVector, ForceMode.VelocityChange);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            waitPointReached = true;
        }

        // move to Swarm and stop
        if (this.transform.position.x < NPCWaitSwarm.transform.position.x && newAllyMoves == true){
            //NPCRigidbody.AddForce(-movementSpeedVector, ForceMode.VelocityChange);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            newAllyMoves = false;

            // spawn new instance of NPC once NPC reached Swarm
            spawnerScript.InstanceOfNPCSpawn();
        }
    }

    public void NPCMove(Vector3 speed){
        // Add a Force to the Rigidbody
        NPCRigidbody.AddForce(movementSpeedVector, ForceMode.VelocityChange);
    }

    public void RotateNPC(float degree){
        Quaternion rotationOfNPC = Quaternion.Euler(degree, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationOfNPC,  Time.deltaTime * 5f);
    }

}
