using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour {

	public Text scoreText;
	public Text coinText;
	Image numberImage;
	public int number = 1;
	Sprite numberSprite;

	// Use this for initialization

	void Start()
	{
		numberImage = this.GetComponent<Image> ();
	}

	public void getNumber(int i)
	{
		print ("number is "+i);
		number = i;
		setValues ();

	}
	void setValues () {
		print ("Setting values for "+number);
		print ("Score is :" + PlayerPrefs.GetInt ("Level " + number + " score", 0).ToString ());
		print ("Coins is :" + PlayerPrefs.GetInt ("Level " + number + " coins", 0).ToString ());
		scoreText.text = PlayerPrefs.GetInt ("Level " + number + " score", 0).ToString ();
		coinText.text = PlayerPrefs.GetInt ("Level " + number + " coins", 0).ToString();
	}

}
