using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingExperimental : MonoBehaviour
{
	//others
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
		if (Input.GetMouseButton(0))
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
		if (currentAmmo <= 0)
		{
			reload ();
		}
	}
}
