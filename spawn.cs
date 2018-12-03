using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
    private float lastSpawnTime;
    public float spawnInterval;
    public GameObject[] duckArray;
    // Use this for initialization
    void Start () {
        lastSpawnTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float timeInterval = Time.time - lastSpawnTime;

        if(timeInterval > spawnInterval)
        {
            lastSpawnTime = Time.time;
            Instantiate(duckArray[Random.Range(0,25)], transform.position, transform.rotation);
        }
    }
}
