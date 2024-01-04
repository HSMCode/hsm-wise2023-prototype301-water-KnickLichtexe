using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Get the Offset between the two Elements Spawner and NPC Wait
*/

public class NPCWait : MonoBehaviour
{

    private Vector3 spawnerPosition;
    public float SpawnerToWaitOffset;

    public float WaitOffset()
    {
        spawnerPosition = GameObject.FindWithTag("Spawner").transform.position;
        SpawnerToWaitOffset = Vector3.Distance(this.transform.position, spawnerPosition);

        return SpawnerToWaitOffset;
    }
}
