using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //basic health components
    public float health;
    public float armor;

    //crash collision components
    public float crashThreshold; //the minimum amount of unit required to affect the object

    public void OnCollisionEnter(Collision collide)
    {
        //crash collision damage
        if (collide.relativeVelocity.magnitude > crashThreshold && health > 0)
        {
            health = Mathf.Round(health - (collide.relativeVelocity.magnitude / armor));
        }
	}
}
