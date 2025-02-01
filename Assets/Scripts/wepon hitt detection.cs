using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExample : MonoBehaviour
{      Collision Collision;
    private void OnDrawGizmosSelected()
    {
        Debug.Log("drawed " + Collision);
       if (Collision != null)
        {
            Debug.Log("drew " + Collision.contacts);
            int i = 0;
            Gizmos.color = Color.red;
            foreach (var item in Collision.contacts) { 
                    Gizmos.DrawSphere(Collision.contacts[i].point, 1);
                    i++;
            }
        }
    }
    // Called when this GameObject starts colliding with another non-trigger collider
    private void OnCollisionEnter(Collision collision)
    { Collision=collision;
        // Get the GameObject of the other collider
        GameObject otherObject = collision.gameObject;

        // Access specific components on the other collider
        Collider otherCollider = collision.collider;
        // Log the name of the other GameObject
        Debug.Log("Collided with: " + otherObject.name + " with "+otherCollider.name+ " colider and collision "+collision);
    }

    // Called while this GameObject is colliding with another
    private void OnCollisionStay(Collision collision)
    {    
        Debug.Log("Still colliding with: " + collision.gameObject.name);
        
    }

    // Called when this GameObject stops colliding with anothers
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Stopped colliding with: " + collision.gameObject.name);
    }

}

