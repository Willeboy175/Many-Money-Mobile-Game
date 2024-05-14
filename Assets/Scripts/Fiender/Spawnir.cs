using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnir : MonoBehaviour
{

    public GameObject greg;

    float timer = 5f;

    

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer<=0)
        {
            SpawnCube();
            timer = 5f;
        }
    }


    void SpawnCube()
    {

        Vector3 position = new Vector3(Random.Range(-20.0F, 20.0F), 1, Random.Range(-20.0F, 20.0F));
        Instantiate(greg, position, Quaternion.identity);
    }
}
