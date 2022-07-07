using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    Transform player;
    Vector3 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3 (player.position.x, player.position.y, player.position.z);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime); //depois que troquei o projetil pra sphere ta se comportando estranho, não vem na minha direção mais 
        if (transform.position == target)
        {
            Destroy(gameObject);
        }
    }

   
}
