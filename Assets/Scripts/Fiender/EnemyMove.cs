using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Transform player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;


   public GameObject rogg;

    void Start()
    {
       rogg = GameObject.FindWithTag("Player");

       player = rogg.GetComponent<Transform>();
    }

    void Update()
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
