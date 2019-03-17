using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    public Canvas pauseScreen;
    public int wishCount;
    public Image wish1;
    public Image wish2;
    public Image wish3;
    private bool alive;
    public int count;
    public Text scoretext;
    public bool day1;
    public bool day2;
    public bool day3;
    public bool day4;
    private int daytype;
    private GameObject moonObj;
    public bool paused;
    private PlayerController player;
    private GameObject[] hazards;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        moonObj = GameObject.FindGameObjectWithTag("moon");
        count = PlayerPrefs.GetInt("Coins",0);
        alive = true;
        wishCount = 3;
        pauseScreen = GameObject.Find("continuescreen").GetComponent<Canvas>();
        pauseScreen.enabled = false;
        paused = false;
        Time.timeScale = 1;
        SetScore();
        PickDay();
        
    }

    public void CheckWish()
    {
        if (wishCount == 3)
        {
            wish1.enabled = true;
            wish2.enabled = true;
            wish3.enabled = true;
        }
        else if (wishCount == 2)
        {
            wish2.enabled = true;
            wish3.enabled = false;
        }
        else if (wishCount == 1)
        {
            wish1.enabled = true;
            wish2.enabled = false;
        }
        else if (wishCount == 0)
        {
            wish1.enabled = false;
        }
        else if (wishCount == -1)
        {
            alive = false;
        }
    }

    private void Update()
    {
        if(alive == false)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("Coins", count);
        SceneManager.LoadScene(0);
    }

    public void ContinueButton()
    {
        hazards = GameObject.FindGameObjectsWithTag("hazard");
        //save half current score here
        count = count / 2;
        PlayerPrefs.SetInt("Coins", count);
        pauseScreen.enabled = false;
        paused = false;
        player.rigid.velocity = Vector2.zero;
        // destroy all hazards currently spawned to allow player time to recup.
        for (var i = 0; i < hazards.Length; i++)
            Destroy(hazards[i]);
        Time.timeScale = 1;
        wishCount--;
        CheckWish();
        SetScore();
    }

    public void GiveUp()
    {
        PlayerPrefs.SetInt("Coins", count);
        SetScore();
        SceneManager.LoadScene(0);
    }

    public void SetScore()
    {
        scoretext.text = "" + count.ToString();
    }

    public void PickDay()
    {
        daytype = Random.Range(0, 4);
        if (daytype == 0)
        {
            day1 = true;
            moonObj.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("day 1");
        }
        else if (daytype == 1)
        {
            day2 = true;
            moonObj.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("day 2");
        }
        else if(daytype == 2)
        {
            day3 = true;
            Debug.Log("day 3");
            PickMoon();
        }
        else if (daytype == 3)
        {
            day4 = true;
            Debug.Log("day 4");
            PickMoon();
        }
    }
    public void PickMoon()
    {
        var moon = 0;
        moon = Random.Range(0, 2);
        if (moon == 0)
        {
            moonObj.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("no moon");
        }
        else if (moon == 1)
        {
            moonObj.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("moon!");
        }
    }

}
