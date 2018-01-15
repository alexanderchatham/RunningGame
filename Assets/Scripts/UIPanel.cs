using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour {

	public static UIPanel instance;
	public Text numberOfCoins;
	public GameObject Panel;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	// Update is called once per frame
	void Update () {
		numberOfCoins.text = PlayerStats.Coins.ToString ();
	}

	public void hide()
	{
		Panel.SetActive (false);
	}
	public void show()
	{
		Panel.SetActive (true);
	}
}
