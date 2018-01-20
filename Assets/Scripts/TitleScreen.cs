using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

    public GameObject panel;
	public static TitleScreen instance;

	void Awake(){
		if (instance == null)
			instance = this;
	}

    public void hide()
    {
        panel.SetActive(false);
    }



}
