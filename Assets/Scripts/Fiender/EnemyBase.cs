using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("")]
    public int hp;
    public int dmg;
    public float atkSpeed;
    public float atkTimer;

    [Header("")]
    public Transform player;
    public int MoveSpeed;
    public int MaxDist;
    public int MinDist;

    public GameObject rogg;
    

    void Start()
    {
        rogg = GameObject.FindWithTag("Player");
        player = rogg.GetComponent<Transform>();
    }
    void Update()
    {
        atkTimer += Time.deltaTime;
        Move();
        if (hp <= 0)
        {
            Die();
        }
    }
    public virtual bool Attack()
    {
        if (atkTimer < atkSpeed)
        {
            return false;
        }
        atkTimer = 0;
        print("Attack");
        return true;
    }
    public virtual void Move()
    {
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
                // h�r den kan g�ra n�got om den kommer n�ra spelaren
            }
        }
    } 
    public void Die()
    {
        Destroy(gameObject);
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            Attack();
        }
    }
}