using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour {

    public static WinPanel instance;
    public GameObject WinScreen;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void show()
    {
        WinScreen.SetActive(true);
    }
}