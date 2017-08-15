using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //basic health components
    public float health;
    public float armor;

    //UI
    public Text dispHP;

    //crash collision components
    public float crashThreshold; //the minimum amount of unit required to affect the object

    private void Start()
    {
        //dispHP = health;
    }

    private void Update()
    {
        //test = dispHP.Invoke.ToString;
    }

    public void OnCollisionEnter(Collision collide)
    {
        //crash collision damage
        if (collide.relativeVelocity.magnitude > crashThreshold && health > 0)
        {
            health = Mathf.Round(health - (collide.relativeVelocity.magnitude / armor));
        }
	}
}
