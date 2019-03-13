using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject[] box;
    public float startRate;
    public float spawnRate;
    private int rand;
	void Start () {
        InvokeRepeating("Spawn", startRate, spawnRate);
	}
	void Spawn () {
        rand = Random.Range(0, box.Length);
        Instantiate<GameObject>(box[rand], transform.position ,Quaternion.identity);
	}
}
