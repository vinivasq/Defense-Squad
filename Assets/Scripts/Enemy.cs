using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int addToScore = 2;
    [SerializeField] int hitPoints = 4;

    ScoreHandler updateScore;

    void Start() 
    {
        
        updateScore = FindObjectOfType<ScoreHandler>();
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
        vfx.transform.parent = parent;
        hitPoints -- ; 
        updateScore.UpdateScore(addToScore);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyExplosionVFX, transform.position, Quaternion.identity); // .identity keeps its original rotation values   
        vfx.transform.parent = parent; 
        Destroy(gameObject);
    }

}
