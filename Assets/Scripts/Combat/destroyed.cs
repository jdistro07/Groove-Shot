using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyed : MonoBehaviour {
    public AudioClip[] audio_destroyed;
    public AudioSource audio_souce;
    public int soundIndex;

    public float respawn_time = 10f;

    public bool isAI;

    void Awake()
    {
        soundIndex = Random.Range(0,audio_destroyed.Length);
        audio_souce.PlayOneShot(audio_destroyed[soundIndex]);
    }

    private void Update()
    {
        respawn_time -= Time.deltaTime;
        var spawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>();
        var AIspawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<AISpawner>();

        bool called = false;

        if (called == false)
        {
            if (respawn_time <= 0)
            {
                if (!isAI)
                {
                    spawn.Spawn_Player();
                    Destroy(gameObject);

                    called = true;
                }else if (isAI)
                {
                    AIspawn.RespawnAI("HGLS (AI)");
                    Destroy(gameObject);

                    called = true;
                }
                
            }
        }
        
    }
}
