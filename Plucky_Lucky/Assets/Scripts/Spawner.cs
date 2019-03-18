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
    private bool collided;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "coin" || collision.tag == "wish" || collision.tag == "hazard" || collision.tag == "TheBigG" || collision.tag == "moreBigG" || collision.tag == "collect")
        {
            collided = true;
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
    }
    void Start()
    {
        InvokeRepeating("Spawn", startRate, spawnRate);
    }
    void Spawn()
    {
        if (!collided)
        {
            itemrand = Random.Range(0, items.Length);
            locrand = Random.Range(0, spawnloc.Length);
            Instantiate<GameObject>(items[itemrand], spawnloc[locrand].transform.position, Quaternion.identity);
        }
    }
}
