using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour {

	public static PausePanel instance;
	public GameObject Panel;
	UIPanel UIP;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		UIP = UIPanel.instance;
	}
	// Update is called once per frame
	public void show()
	{
		Time.timeScale = 0;
		GameMaster.EndGame ();
		Panel.SetActive(true);
		UIP.hide ();
	}
	public void hide()
	{
		Panel.SetActive(false);
		Time.timeScale = 1;
		GameMaster.GetSpeed ();
        GameMaster.reverse(GameMaster.reversed);
		UIP.show ();
	}
}
