using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimate : MonoBehaviour
{
    public void PlayButtonAnim()
    {
        GetComponent<Animator>().SetBool("pressed", true);
    }
    public void StopButtonAnim()
    {
        GetComponent<Animator>().SetBool("pressed", false);
    }
}
