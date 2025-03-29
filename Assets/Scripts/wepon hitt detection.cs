using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExample : MonoBehaviour
{      Collision Collision;
    float force;
    private void OnDrawGizmos()
    {
        
       if (Collision != null & force > 0)
        {
            
           int i = 0;
            Gizmos.color = Color.red;
            foreach (var item in Collision.contacts) { 
                    Gizmos.DrawSphere(Collision.contacts[i].point, force*0.1f);
                    i++;
            }
            
        }
    }
    // Called when this GameObject starts colliding with another non-trigger collider
    private void OnCollisionEnter(Collision collision)
    { Collision=collision;
        force = collision.relativeVelocity.magnitude;
        // Get the GameObject of the other collider
        GameObject otherObject = collision.gameObject;

        // Access specific components on the other collider
        Collider otherCollider = collision.collider;
        // Log the name of the other GameObject
        Debug.Log("Collided with: " + otherObject.name + " with "+otherCollider.name+ " colider and collision "+collision+" at "+force+"speed ");
        
        if (collision.gameObject.CompareTag("enemy")) {
            Material material = otherObject.GetComponent<MeshRenderer>().material;
            float r = material.color.r;
            Color c = material.color;
            c[0] = r + 0.1f*force;
            material.color= c;
            if(otherObject.GetComponent<Dsamage_Handeler>() != null) { 
            otherObject.GetComponent<Dsamage_Handeler>().Take(force);}
            Debug.Log("dealt "+force);
        }
    }

    // Called while this GameObject is colliding with another
    public void Update ()
    {   

        if (force > 0) {
            force -=  0.05f;
        }
    }

    // Called when this GameObject stops colliding with anothers
    //private void OnCollisionExit(Collision collision)
    //{
        //Collision = null;
        
    //}

}

