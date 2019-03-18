using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour {
    public GameObject[] airitems;
    public GameObject[] grounditems;
    public GameObject groundspawnloc;
    public GameObject[] airspawnloc;
    public float airstartRate;
    public float airspawnRate;
    public float groundstartRate;
    public float groundspawnRate;
    private int airrand;
    private int groundrand;
    private int locrand;
    private bool collided;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("spawn"))
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
        InvokeRepeating("airSpawn", airstartRate, airspawnRate);
        InvokeRepeating("groundSpawn", groundstartRate, groundspawnRate);
    }
    void airSpawn()
    {
        if (!collided)
        {
            airrand = Random.Range(0, airitems.Length);
            locrand = Random.Range(0, airspawnloc.Length);
            Instantiate<GameObject>(airitems[airrand], airspawnloc[locrand].transform.position, Quaternion.identity);
        }
    }
    void groundSpawn()
    {
        if (!collided)
        {
            groundrand = Random.Range(0, grounditems.Length);
            Instantiate<GameObject>(grounditems[groundrand], groundspawnloc.transform.position, Quaternion.identity);
        }
    }
}
