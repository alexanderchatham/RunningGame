using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinShooter : MonoBehaviour {
    public GameObject coin;
    GameObject coinCopy;
    public float timebetween = 1f;
	float temp;
    Transform thisposition;
	// Use this for initialization
	void Start () {
        thisposition = this.transform;
		temp = timebetween;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (temp > 0f)
        {
			temp = temp - .01f;
            return;
        }
        coinCopy = Instantiate(coin,thisposition);

		temp = timebetween;
	}
}
