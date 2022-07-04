using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int addToScore = 2;
    [SerializeField] int hitPoints = 4;

    ScoreHandler updateScore;
    GameObject parentGameObject;


    void Start()
    {
        AddRigidbody();
        updateScore = FindObjectOfType<ScoreHandler>();
        parentGameObject = GameObject.FindWithTag("Runtime Spawner");
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
   
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        } 
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate (hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints -- ; 
        updateScore.UpdateScore(addToScore);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyExplosionVFX, transform.position, Quaternion.identity); // .identity keeps its original rotation values   
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

}
