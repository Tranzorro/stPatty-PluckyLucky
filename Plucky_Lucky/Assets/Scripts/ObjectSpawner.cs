using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject[] box;
    public float startRate;
    public float spawnRate;
    private int rand;
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
    void Start () {
        InvokeRepeating("Spawn", startRate, spawnRate);
	}
	void Spawn () {
        if (!collided)
        {
            rand = Random.Range(0, box.Length);
            Instantiate<GameObject>(box[rand], transform.position, Quaternion.identity);
        }
	}
}
