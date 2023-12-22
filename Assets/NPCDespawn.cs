using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDespawn : MonoBehaviour
{
  // Destroy GameObject once it hits the Despawner GameObject
  void OnCollisionEnter (Collision collision)
  {
    if (collision.collider.tag == "NPC")
    {

      GameObject collisionObject;
      collisionObject = collision.gameObject;
      
      Destroy(collisionObject);
      
    }
  }
}
