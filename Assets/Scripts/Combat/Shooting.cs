﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	//projectile
	public float projectileSpeed;
	public Rigidbody projectile;
	public Transform projectileOrigin;

    //type
    public bool OneShot;

	//audio
	public AudioClip cannonSound;
    public AudioSource audio_source;

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentAmmo != maxAmmo)
            {
                currentAmmo = 0;
                reload();
            }
        }

        if (OneShot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > fireDelay + lastShot && currentAmmo > 0)
                {
                    //deduct 1 bullet at a time
                    currentAmmo -= 1;
                    Rigidbody projectileInstance;
                    audio_source.PlayOneShot(cannonSound);
                    particleEffects.Emit(1);

                    projectileInstance = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation) as Rigidbody;
                    //projectileInstance.velocity = transform.TransformDirection (Vector3.forward * projectileSpeed);
                    projectileInstance.AddForce(projectileOrigin.forward * projectileSpeed);
                    lastShot = Time.time;
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
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
        }
	}

	void LateUpdate()
	{
        reload();
	}

    void reload()
    {
        if (Time.time > reloadTime + lastShot)
        {
            currentAmmo = maxAmmo;
        }
    }
}
