using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour {

	public static StartPanel instance;
	public GameObject Panel;
	LevelPanel LP;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		LP = LevelPanel.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void show()
	{
		LP.hide ();
		Panel.SetActive(true);
	}
	public void hide()
	{
		Panel.SetActive(false);
	}
}
