using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float speed;
	void Update () {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if(transform.position.x <= -20)
        {
            Destroy(gameObject);
        }
	}
}
