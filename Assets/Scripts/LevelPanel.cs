using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPanel : MonoBehaviour {

	public static LevelPanel instance;
	public GameObject Panel;
	public Image buttonImage;
	StartPanel SP;
	public GameObject content;
	public GameObject numberButtonPrefab;
	LevelSelectButton LSB;
	bool filled = false;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		SP = StartPanel.instance;
	}
	
	void fillButtons()
	{
		bool addAnotherButton = true;
        int numberOfButtons = 0;
		if(!filled)
		for (int i = 1; i <= GameMaster.MaxLevel; i++)
		{
			if(PlayerPrefs.GetInt("Level " + i, 0) == 1 || addAnotherButton){
					if (PlayerPrefs.GetInt ("Level " + i, 0) == 0)
						addAnotherButton = false;
				GameObject numberButton = (GameObject)Instantiate (numberButtonPrefab,content.transform);
				LSB = numberButton.GetComponent<LevelSelectButton> ();
				LSB.getNumber (i);
                numberButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(i+"button");
				numberButton.name = i.ToString();
				print ("adding listener to : "+i);
				numberButton.GetComponent<Button> ().onClick.AddListener (() => onClickLevelSelect (numberButton));
                numberOfButtons++;
			}
		}
		filled = true;
	}

	public void onClickLevelSelect(GameObject b)
	{
		print ("button name is: " + b.name);
		int i = int.Parse(b.name);
		if (i <= GameMaster.MaxLevel)
		{
			SceneManager.LoadScene (i, LoadSceneMode.Single);
			GameMaster.EndGame ();
		}
	}

	public void show()
	{
		SP.hide ();
		fillButtons ();
		Panel.SetActive(true);
	}
	public void hide()
	{
		Panel.SetActive(false);
	}
}
