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
    public Transform Player;
    public int MoveSpeed;
    public int MaxDist;
    public int MinDist;


    void Start()
    {

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
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                // här den kan göra något om den kommer nära spelaren
            }
        }
    }
}