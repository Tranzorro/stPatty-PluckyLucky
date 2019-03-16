using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] items;
    public GameObject[] spawnloc;
    public float startRate;
    public float spawnRate;
    private int itemrand;
    private int locrand;
    void Start()
    {
        InvokeRepeating("Spawn", startRate, spawnRate);
    }
    void Spawn()
    {
        itemrand = Random.Range(0, items.Length);
        locrand = Random.Range(0, spawnloc.Length);
        Instantiate<GameObject>(items[itemrand], spawnloc[locrand].transform.position, Quaternion.identity);
    }
}
