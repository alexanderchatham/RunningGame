using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour {

	public static LevelPanel instance;
	public GameObject Panel;
	StartPanel SP;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		SP = StartPanel.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void show()
	{
		SP.hide ();
		Panel.SetActive(true);
	}
	public void hide()
	{
		Panel.SetActive(false);
	}
}
