using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticBulletFire : MonoBehaviour {

    public float launchTime = 5f;

    public float projectileSpeed;
    public Rigidbody projectile;
    public Transform projectileOrigin;

    void launchProjectile()
    {
        launchTime -= Time.deltaTime;

        if (launchTime < 0f)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation) as Rigidbody;
            projectileInstance.AddForce(projectileOrigin.forward * projectileSpeed);

            if(launchTime <= 0)
            {
                launchTime += 2;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        launchProjectile();
	}
}
