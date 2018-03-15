using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    private int maxsongs = 2;
    // Use this for initialization
    void Start()
    {

        int i = PlayerPrefs.GetInt("Volume", 20);
        GameObject music = GameObject.FindGameObjectWithTag("music");
        music.GetComponent<AudioSource>().volume = ((float)(i * 5)) / 100;
        int j = PlayerPrefs.GetInt("song", 0);
        if (j == 0)
        {
            music.GetComponent<AudioSource>().clip = Resources.Load("Sounds/runninginhell") as AudioClip;
            music.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("song", j + 1);
        }
        else
        {
            if (j >= maxsongs)
            {
                j = 0;
                music.GetComponent<AudioSource>().clip = Resources.Load("Sounds/runninginhell") as AudioClip;
                Debug.Log("music is:" + j);
                music.GetComponent<AudioSource>().Play();
                PlayerPrefs.SetInt("song", j + 1);
                return;
            }
            else
            {
                music.GetComponent<AudioSource>().clip = Resources.Load("Sounds/runninginhell" + j) as AudioClip;
                music.GetComponent<AudioSource>().Play();
                PlayerPrefs.SetInt("song", j + 1);
                Debug.Log("music is:" + j);
            }
        }
    }
    
}
