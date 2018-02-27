using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinShooter : MonoBehaviour {
    public GameObject coin;
    GameObject coinCopy;
    public float timebetween = 1f;
    Transform thisposition;
	// Use this for initialization
	void Start () {
        thisposition = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        while (timebetween > 0f)
        {
            timebetween = timebetween - .01f;
            return;
        }
        coinCopy = Instantiate(coin,thisposition);
        timebetween = .2f;
	}
}
