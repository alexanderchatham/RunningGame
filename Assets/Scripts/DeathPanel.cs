using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour {

    public static DeathPanel instance;
    public GameObject DeathScreen;

    private void Awake()
    {
        if(instance == null)
        instance = this;
    }
    public void show()
    {
        DeathScreen.SetActive(true);
    }
}
