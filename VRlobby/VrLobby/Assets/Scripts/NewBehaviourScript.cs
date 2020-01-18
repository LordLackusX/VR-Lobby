using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public float pushStrengh = 6.0f, speedupStrengh = 10.0f;
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {


        Rigidbody Body = hit.collider.attachedRigidbody;

        if (Body == null || Body.isKinematic)
        {
            return;

        }
            
        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 direction = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        Body.velocity = direction * pushStrengh;


    }
}
