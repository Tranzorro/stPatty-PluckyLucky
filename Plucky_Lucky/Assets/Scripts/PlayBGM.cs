using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour {
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioSource source;
    private Manager manager;
    void Start ()
    {
        source = gameObject.GetComponent<AudioSource>();
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>();
        source.PlayOneShot(audio1);
	}
    private void Update()
    {
        if (!source.isPlaying)
        {
            if (manager.paused)
            {
                source.PlayOneShot(audio2);
            }
            else if (!manager.paused)
            {
                source.PlayOneShot(audio1);
            }
        }
    }
}
