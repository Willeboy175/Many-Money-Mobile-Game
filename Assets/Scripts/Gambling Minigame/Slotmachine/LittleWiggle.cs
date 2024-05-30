using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleWiggle : MonoBehaviour
{
    public bool wiggle = false;
    public float wiggleSpeed;
    public float timer = 0;
    bool x = true;
    
   
    void Update()
    {
        if (wiggle)
        {
            if (x == true)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            
            transform.eulerAngles = new Vector3(0, 0, timer * 4);
            if (timer > 1)
            {
                x = false;
            }
            if (timer < -1)
            {
                x = true;
            }
        }
       
    }

    
}
