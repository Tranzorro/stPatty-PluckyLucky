using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySpriteChange : MonoBehaviour {
    private SpriteRenderer cloudSprite;
    public Sprite[] cloudSprites;
    private Manager manager;

    void Start()
    {
        manager = GameObject.FindObjectOfType<Manager>();
        cloudSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (manager.day1)
        {
            cloudSprite.sprite = cloudSprites[0];
        }
        else if (manager.day2)
        {
            cloudSprite.sprite = cloudSprites[1];
        }
        else if (manager.day3)
        {
            cloudSprite.sprite = cloudSprites[2];
        }
        else if (manager.day4)
        {
            cloudSprite.sprite = cloudSprites[3];
        }
    }
}
