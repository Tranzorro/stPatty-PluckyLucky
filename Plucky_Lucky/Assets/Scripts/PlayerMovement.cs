using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rigid;
    public float thrust;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0)||Input.touchCount >0)
        {
            rigid.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }
        
    }
}
