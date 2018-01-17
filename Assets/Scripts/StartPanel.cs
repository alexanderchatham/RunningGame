using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour {

	public static StartPanel instance;
	public GameObject Panel;
	LevelPanel LP;
	public Text numberOfCoins;
	public Text score;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		numberOfCoins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
		score.text = PlayerPrefs.GetInt("Score", 0).ToString();
		LP = LevelPanel.instance;
	}
	void Update(){

		numberOfCoins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
		score.text = PlayerPrefs.GetInt("Score", 0).ToString();
	}

    public void show()
	{
		numberOfCoins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
		score.text = PlayerPrefs.GetInt("Score", 0).ToString();
		LP.hide ();
		Panel.SetActive(true);
	}
	public void hide()
	{
		Panel.SetActive(false);
	}
}
