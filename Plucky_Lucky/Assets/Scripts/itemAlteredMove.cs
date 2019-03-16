using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemAlteredMove : MonoBehaviour {
    public float speed;
    private bool collided;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "coin"||collision.tag =="wish"|| collision.tag == "hazard"||collision.tag =="TheBigG"||collision.tag == "moreBigG"||collision.tag =="collect")
        {
            collided = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
    }
    void Update()
    {
        if (!collided)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            if (transform.position.x <= -20)
            {
                Destroy(gameObject);
            }
        }
    }
}
