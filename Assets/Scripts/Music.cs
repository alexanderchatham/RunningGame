using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Start () {

        int i = PlayerPrefs.GetInt("Volume", 20);
        GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().volume = ((float)(i * 5)) / 100;

    }
    
}
