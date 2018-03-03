using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxVolumesetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<AudioSource>().volume = (float)((PlayerPrefs.GetInt("SfxVolume", 20)*5)/100f);
	}
	
	
}
