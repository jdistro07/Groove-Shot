using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjectOnCollission : MonoBehaviour
{
    public AudioClip bulletCrash;
    private float shotTime;
    public float airTime;

    private void Awake()
    {
        GetComponent<AudioSource>().PlayDelayed(0.1f);
        GetComponent<AudioSource>().Play();
    }

    void Start()
    {
        shotTime = Time.time;

    }

    void FixedUpdate()
    {
        if(Time.time > airTime + shotTime) {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter(Collision hit)
	{
        AudioSource.PlayClipAtPoint(bulletCrash, new Vector3(transform.position.x,transform.position.y,transform.position.z));

        GetComponent<AudioSource>().Stop();
		Destroy (gameObject);
	}
}
