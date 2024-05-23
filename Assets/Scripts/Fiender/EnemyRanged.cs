using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyBase
{

    [SerializeField] float shootCooldown;
    float shootTimer = 0;
    [SerializeField] GameObject enemyProjectile;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootCooldown)
        {
            Instantiate(enemyProjectile, transform.position, transform.rotation);
            shootTimer = 0;
        }

    }

    
}
