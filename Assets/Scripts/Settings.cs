using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public static Settings instance;
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


    public void show()
    {
        SP.hide();
        Panel.SetActive(true);
    }
    public void hide()
    {
        SP.show();
        Panel.SetActive(false);
    }
}
