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
        Move();
    }

    public virtual bool AtkSpeed()
    {
        if (atkTimer < atkSpeed)
        {
            print("2 fast");
            return false;
        }
        atkTimer = 0;
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
                // här den kan göra något om den kommer nära spelaren
            }
        }
    }
}