using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randoSprite : MonoBehaviour {

    private SpriteRenderer charSprite;
    public Sprite[] charSprites;

    void Start () {
        charSprite = gameObject.GetComponent<SpriteRenderer>();
        charSprite.sprite = charSprites[Random.Range(0,charSprites.Length)];
    }
}
