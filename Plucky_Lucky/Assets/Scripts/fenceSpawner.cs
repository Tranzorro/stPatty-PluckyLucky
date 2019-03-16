using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenceSpawner : MonoBehaviour {
    public GameObject[] tiles;
    public GameObject spawnpos;
    public float startRate;
    public float spawnRate;
    private bool overlap = false;
    private int rand;
    void Start () {
        InvokeRepeating("Spawn", startRate, spawnRate);
	}
    void Spawn()
    {
        rand = Random.Range(0, tiles.Length);
        if(transform.position.x < 20)
        {
            Instantiate<GameObject>(tiles[rand], spawnpos.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fence")
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
