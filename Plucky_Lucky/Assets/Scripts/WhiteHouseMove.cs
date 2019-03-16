using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteHouseMove : MonoBehaviour {
    public float speed;
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x <= -25)
        {
            Debug.Log("uh... im below -25 x now...");
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
        }
    }
}
