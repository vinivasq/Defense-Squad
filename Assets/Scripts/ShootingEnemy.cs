using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
 
    [SerializeField] GameObject enemyExplosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int addToScore = 2;
    [SerializeField] int hitPoints = 4;
    [SerializeField] GameObject projectile;
    [SerializeField] float startTimeBtwShots;
    float timeBtwShots;
    ScoreHandler updateScore;
    GameObject parentGameObject;


    void Start()
    {
        AddRigidbody();
        timeBtwShots = startTimeBtwShots;
        updateScore = FindObjectOfType<ScoreHandler>();
        parentGameObject = GameObject.FindWithTag("Runtime Spawner");
    }

    void Update()
    {
        ProcessShooting();

    }

    void ProcessShooting()
    {
        if (timeBtwShots <= 0)
        {
            GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity);
            shot.transform.parent = parentGameObject.transform;
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
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
