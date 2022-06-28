using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyCrashVFX;
    [SerializeField] Transform parent;

    void OnParticleCollision(GameObject other) 
    {
        GameObject vfx = Instantiate(enemyCrashVFX, transform.position, Quaternion.identity); // .identity keeps its original rotation values   
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
   
}
