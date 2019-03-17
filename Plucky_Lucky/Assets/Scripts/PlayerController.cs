using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D rigid;
    private Manager manager;
    public float thrust;
    public float bigG;
    private SpriteRenderer charSprite;
    public Sprite[] charSprites;
    private PlayBGM bgm;
    private AudioSource source;
    public AudioClip audioCoin;
    public AudioClip hurt;
    void Start() {
        source = GetComponent<AudioSource>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        charSprite = gameObject.GetComponent<SpriteRenderer>();
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>();
        charSprite.sprite = charSprites[0];
        bigG = 0f;
        bgm = FindObjectOfType<PlayBGM>();
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
            source.clip = audioCoin;
            source.Play();
            manager.count ++;
            manager.SetScore();
        }
        else if (other.gameObject.tag == "wish")
        {
            source.clip = audioCoin;
            source.Play();
            if (manager.wishCount < 3)
            {
                manager.wishCount++;
                manager.CheckWish();
            }
        }
        else if (other.gameObject.tag == "hazard")
        {
            if (manager.wishCount > 0)
            {
                source.clip = hurt;
                source.Play();
                Time.timeScale = 0;
                rigid.velocity = Vector2.zero;
                manager.pauseScreen.enabled = true;
                manager.paused = true;
                bgm.source.Stop();
            }
            else if (manager.wishCount == 0)
            {
                manager.GameOver();
            }
        }
        else if (other.gameObject.tag == "TheBigG")
        {
            source.clip = audioCoin;
            source.Play();
            bigG += 0.1f;
        }
        else if (other.gameObject.tag == "moreBigG")
        {
            source.clip = audioCoin;
            source.Play();
            bigG -= 0.1f;
        }
    }
}