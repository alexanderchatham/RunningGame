using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartPanel : MonoBehaviour {

    public GameObject panel;

	public void hide()
    {
        panel.SetActive(false);
    }
}
