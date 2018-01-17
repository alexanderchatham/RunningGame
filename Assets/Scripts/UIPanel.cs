using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour {

	public static UIPanel instance;
	public Text numberOfCoins;
    public Text Score;
	public GameObject Panel;

	 void Awake()
	{
		if (instance == null)
			instance = this;
	}


    // Update is called once per frame
    void Update () {
		numberOfCoins.text = PlayerStats.Coins.ToString ();
        Score.text = PlayerStats.Score.ToString();
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
