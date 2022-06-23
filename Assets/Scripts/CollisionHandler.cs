using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log($"{this.name} ---Collided with--- {other.gameObject.name}");
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{this.name} ***Triggered*** {other.gameObject.name}");
    }

}
