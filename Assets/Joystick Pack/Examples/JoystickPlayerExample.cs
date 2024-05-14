using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        if (rb.velocity.magnitude < 20)
        {
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        //rb.(rb.position + direction * speed * Time.deltaTime);
    }
}