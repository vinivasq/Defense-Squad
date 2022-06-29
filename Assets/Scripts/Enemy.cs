using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyCrashVFX;
    [SerializeField] Transform parent;
    [SerializeField] int addToScore = 2;
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
        GameObject vfx = Instantiate(enemyCrashVFX, transform.position, Quaternion.identity); // .identity keeps its original rotation values   
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

}
