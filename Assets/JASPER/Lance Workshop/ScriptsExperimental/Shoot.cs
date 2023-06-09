﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	//others
	public bool player = true;
	public bool singleBarrel = true;
	private bool firing = false;

	//projectile
	public float projectileSpeed;
	public Rigidbody projectile;
	public Transform projectileOrigin;

	//audio
	public AudioClip cannonSound;

	//visual effects
	public ParticleSystem particleEffects;

	//rate of fire
	public float fireDelay = 1.0f;
	private float lastShot = 0.0f;

	//Ammunition
	public int maxAmmo = 7;
	public int currentAmmo;
	public float reloadTime = 3;

	void Awake()
	{
		currentAmmo = maxAmmo;
	}

	void Update ()
	{
		if (player == true)
		{
			if (Input.GetMouseButton(0))
			{
				if (singleBarrel == true)
				{
					SingleBarrel ();
				}
				else
				{
					TwinBarrel ();
				}
			}
		}
	}

	public void SingleBarrel()
	{
		if (Time.time > fireDelay + lastShot && currentAmmo > 0)
		{
			//deduct 1 bullet at a time
			currentAmmo -= 1;
			Rigidbody projectileInstance;
			GetComponent<AudioSource>().PlayOneShot(cannonSound);
			particleEffects.Emit(1);

			projectileInstance = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation) as Rigidbody;
			//projectileInstance.velocity = transform.TransformDirection (Vector3.forward * projectileSpeed);
			projectileInstance.AddForce(projectileOrigin.forward * projectileSpeed);
			lastShot = Time.time;
		}
	}

	public void TwinBarrel()
	{
		if (Time.time > fireDelay + lastShot && currentAmmo > 0)
		{
			if (firing == false)
			{
				currentAmmo -= 1;
				Rigidbody projectileInstance;
				projectileOrigin = transform.Find ("bulletspawn1");
				particleEffects.transform.position = transform.Find ("particlepos1").position;
				GetComponent<AudioSource>().PlayOneShot(cannonSound);
				particleEffects.Emit(1);

				projectileInstance = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation) as Rigidbody;
				projectileInstance.AddForce(projectileOrigin.forward * projectileSpeed);
				lastShot = Time.time;
				firing = true;
			}
			else
			{
				currentAmmo -= 1;
				Rigidbody projectileInstance;
				projectileOrigin = transform.Find ("bulletspawn2");
				particleEffects.transform.position = transform.Find ("particlepos2").position;
				GetComponent<AudioSource>().PlayOneShot(cannonSound);
				particleEffects.Emit(1);

				projectileInstance = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation) as Rigidbody;
				projectileInstance.AddForce(projectileOrigin.forward * projectileSpeed);
				lastShot = Time.time;
				firing = false;
			}
		}
	}

	void reload()
	{
		if (Time.time > reloadTime + lastShot)
		{
			currentAmmo = maxAmmo;
		}
	}

	void FixedUpdate()
	{
		if (currentAmmo == 0)
		{
			reload ();
		}
	}
}
