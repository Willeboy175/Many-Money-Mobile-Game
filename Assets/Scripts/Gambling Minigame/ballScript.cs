using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    pachinko pachi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "1")
        {
            pachi.money += 17;
            ballDie();        
        }

        if (other.gameObject.tag == "2")
        {
            pachi.money += 10;
            ballDie();
        }

        if (other.gameObject.tag == "3")
        {
            pachi.money += 3;
            ballDie();
        }

        if (other.gameObject.tag == "4")
        {
            pachi.money += 1;
            ballDie();
        }
    }

    void ballDie()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        pachi = FindObjectOfType<pachinko>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
