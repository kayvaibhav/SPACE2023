using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidKillZone : MonoBehaviour
{
    //Note : OnCollision() requires both objects to have a rigidbody component while OnTriggerEnter() requires only one of the objects to have a rigidbody component.
    //Note : OnCollision() is called when the collider is in contact with another collider while OnTriggerEnter() is called when the collider enters the trigger collider.
    //Note : OnCollision() is called every frame while OnTriggerEnter() is called only once.
    //Note : OnCollision() is called when the collider is in contact with another collider while OnTriggerEnter() is called when the collider enters the trigger collider.

    //asteroid prefab was not a rigid body so that they dont collide with each other. so only the the AsteroidKillZone needs to have a rigidbody component.

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Asteroid") //if(collison.gameObject.CompareTag("Asteroid"))
    //     {
    //         Destroy(collision.gameObject);
    //     }
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid") //if(collison.gameObject.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
        }
    }
}
