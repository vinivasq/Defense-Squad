using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int addToScore = 2;
    [SerializeField] int hitsToDie = 3;

    int hitCount = 0;
    ScoreHandler updateScore;

    void Start() 
    {
        
        updateScore = FindObjectOfType<ScoreHandler>();
    }

    void OnParticleCollision(GameObject other)
    {
        IncreaseScore();
        
        KillEnemy();
    }

    void IncreaseScore()
    {
        updateScore.UpdateScore(addToScore);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyExplosionVFX, transform.position, Quaternion.identity); // .identity keeps its original rotation values   
        vfx.transform.parent = parent;
        hitCount ++ ;  //ver video aula e tentar resolver o bug que o inimigo nave esta explodindo ao runtime
        if (hitCount >= hitsToDie)
        {
            Destroy(gameObject);
        }
    }

}
