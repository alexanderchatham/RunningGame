using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public static Store instance;
	public GameObject Panel;
	StartPanel SP;
	public Text numberOfCoins;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		SP = StartPanel.instance;
	}
    

	public void show()
	{
		numberOfCoins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
		SP.hide ();
		Panel.SetActive(true);
	}
	public void hide()
	{
		SP.show ();
		Panel.SetActive(false);
	}
}
