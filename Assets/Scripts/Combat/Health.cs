using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //basic health components
    public float health;
    public float armor;
    public GameObject destroyed;

    //crash collision components
    public float crashThreshold; //the minimum amount of unit required to affect the object

    public void OnCollisionEnter(Collision collide)
    {
		//bullet damage
		if (collide.gameObject.tag == "bullet") {
			var dam = GameObject.FindGameObjectWithTag ("bullet").GetComponent<RemoveObjectOnCollission> ();
			health -= Mathf.Round((dam.damage * (collide.relativeVelocity.magnitude / 50)) / armor);
		}
		else
		{
			//crash collision damage
			if (collide.relativeVelocity.magnitude > crashThreshold && health > 0)
			{
				health = Mathf.Round(health - (collide.relativeVelocity.magnitude / armor));
			}
		}

        if (health<=0)
        {
            Destroy(gameObject);
            Instantiate(destroyed,transform.position,transform.rotation);
			HUDController.score++;
        }
	}
}
