using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyed : MonoBehaviour {
    public AudioClip[] audio_destroyed;
    public AudioSource audio_souce;
    public int soundIndex;

    public float respawn_time = 10f;

    //ai properties
    public bool isAI;
    public GameObject AIObject;
    public List<GameObject> spawn;

    void Awake()
    {
        soundIndex = Random.Range(0,audio_destroyed.Length);
        audio_souce.PlayOneShot(audio_destroyed[soundIndex]);
    }

    private void Start()
    {
        foreach (GameObject spawnPoints in GameObject.FindGameObjectsWithTag("Spawn"))
        {
            spawn.Add(spawnPoints);
        }
    }

    private void Update()
    {
        respawn_time -= Time.deltaTime;

        bool called = false;

        if (called == false)
        {
            if (respawn_time <= 0)
            {
                if (isAI)
                {
                    int spawnIndex = Random.Range(0,spawn.Count);
                    Instantiate(AIObject, spawn[spawnIndex].transform.position, spawn[spawnIndex].transform.rotation);
                    Destroy(gameObject);

                    called = true;
                }
                else
                {
                    var spawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>();
                    Destroy(gameObject);
                    spawn.Spawn_Player();

                    called = true;
                }
            }
        }
        
    }
}
