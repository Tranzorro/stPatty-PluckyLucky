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
    void Start()
    {
        InvokeRepeating("airSpawn", airstartRate, airspawnRate);
        InvokeRepeating("groundSpawn", groundstartRate, groundspawnRate);
    }
    void airSpawn()
    {
        airrand = Random.Range(0, airitems.Length);
        locrand = Random.Range(0, airspawnloc.Length);
        Instantiate<GameObject>(airitems[airrand], airspawnloc[locrand].transform.position, Quaternion.identity);
    }
    void groundSpawn()
    {
        groundrand = Random.Range(0, grounditems.Length);
        Instantiate<GameObject>(grounditems[groundrand], groundspawnloc.transform.position, Quaternion.identity);
    }
}
