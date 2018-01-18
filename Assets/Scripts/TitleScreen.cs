using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

    public GameObject panel;

    public void hide()
    {
        panel.SetActive(false);
    }
}
