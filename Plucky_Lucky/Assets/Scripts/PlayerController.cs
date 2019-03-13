using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rigid;
    private Manager manager;
    public float thrust;
    public float bigG;
    public Canvas pauseScreen;
    private SpriteRenderer charSprite;
    public Sprite[] charSprites;
    void Start() {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        charSprite = gameObject.GetComponent<SpriteRenderer>();
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>();
        pauseScreen = GameObject.Find("continuescreen").GetComponent<Canvas>();
        charSprite.sprite = charSprites[0];
        bigG = 0f;
    }
	void Update () {
        if(Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            rigid.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            if (manager.count <= 10)
            {
                rigid.gravityScale = 1 - bigG;
            }
            else if (manager.count <= 50)
            {
                rigid.gravityScale = 1.5f - bigG;
            }
            else if (manager.count <= 100)
            {
                rigid.gravityScale = 2 - bigG;
            }
        }
        if(rigid.velocity.y < -1)
        {
            charSprite.sprite = charSprites[2];
        }
        else if (rigid.velocity.y > 1)
        {
            charSprite.sprite = charSprites[1];
        }
        else
        {
            charSprite.sprite = charSprites[0];
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            manager.count ++;
            manager.SetScore();
        }
        else if (other.gameObject.tag == "wish")
        {
            if(manager.wishCount < 3)
            {
                manager.wishCount++;
                manager.CheckWish();
            }
        }
        else if (other.gameObject.tag == "hazard")
        {
            if (manager.wishCount > 0)
            {
                Time.timeScale = 0;
                pauseScreen.enabled = true;
            }
            else if (manager.wishCount == 0)
            {
                manager.GameOver();
            }
        }
        else if (other.gameObject.tag == "TheBigG")
        {
            bigG += 0.1f;
        }
    }
}