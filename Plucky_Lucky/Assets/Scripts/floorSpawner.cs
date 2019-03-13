using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSpawner : MonoBehaviour {
    public GameObject tile;
    public float startRate;
    public float spawnRate;
    private bool overlap = false;
    void Start () {
        InvokeRepeating("Spawn", startRate, spawnRate);
	}
    void Spawn()
    {
        if(transform.position.x < 20)
        {
            Instantiate<GameObject>(tile, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            overlap = true;
            Debug.Log("overlapped!");
        }
    }
    private void Update()
    {
        if (overlap)
        {
            Destroy(transform.root.gameObject);
        }
    }
}
