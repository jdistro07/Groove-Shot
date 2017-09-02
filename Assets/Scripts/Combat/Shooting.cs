using System.Collections;
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
        if (OneShot)
        {
            if (Input.GetMouseButtonDown(0))
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
