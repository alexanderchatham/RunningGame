using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour {

	public GameObject UIpanel;
	public Text numberOfCoins;
	// Update is called once per frame
	void Update () {
		numberOfCoins.text = PlayerStats.Coins.ToString ();
	}
}
