using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour {

    public static WinPanel instance;
    public GameObject WinScreen;
	public Text s;
	public Text hs;
	public Text c;
	public Text hc;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void show()
    {
        WinScreen.SetActive(true);
    }
	public void setScore(int i){
		s.text = ""+i;
	}
	public void setHighscore(int i){
		hs.text = ""+i;
	}
	public void setCoins(int i){
		c.text = ""+i;
	}
	public void setBestCoins(int i){
		hc.text = ""+i;
	}
}