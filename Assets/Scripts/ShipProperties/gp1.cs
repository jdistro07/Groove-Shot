using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gp1 : MonoBehaviour {

    private int hp = 1;
    public ParticleSystem explosion;

    void Update()
    {
        if (hp <= 0)
        {
            explosion.Emit(1);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision clash)
    {
        hp -= 1;
    }

}
