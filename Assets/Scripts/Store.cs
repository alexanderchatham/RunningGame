using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public static Store instance;
	public GameObject Panel;
	StartPanel SP;
	public Text numberOfCoins;
    public Text notEnough;
    public Button Orange;
    public Button fire;
    public Button tree;

    private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		SP = StartPanel.instance;
	}

    public void selectCharacter(int i)
    {
        int cost = 0;
        switch (i)
        {
            case 0:
                cost = 0;
                break;
            case 1:
                cost = 0;
                break;
            case 2:
                cost = 0;
                break;
            default:
                break;
        }
        if (PlayerStats.totalCoins >= cost || 1 == PlayerPrefs.GetInt("Character " + i + " unlocked", 0))
        {
            shadowFunction(i);
            PlayerStats.spendCoin(cost);
            PlayerPrefs.SetInt("Character " + i + " unlocked" , 1);
            print("Selecting Character: " + i);
            PlayerPrefs.SetInt("Character", i);
        }
        else
        {
            notEnough.enabled = false;
            print("enabling not enough");
            notEnough.enabled = true;
        }
    }

    void shadowFunction(int i)
    {
        switch (i)
        {
            case 0:
                activateShadows(Orange);
                deactivateShadows(fire);
                deactivateShadows(tree);
                break;
            case 1:
                activateShadows(fire);
                deactivateShadows(Orange);
                deactivateShadows(tree);
                break;
            case 2:
                activateShadows(tree);
                deactivateShadows(fire);
                deactivateShadows(Orange);
                break;
        }
    }

    void activateShadows(Button b)
    {
      Shadow[] shadows =  b.GetComponents<Shadow>();
        for(int i = 0; i < shadows.Length; i++)
        {
            shadows[i].enabled = true;
        }
    }

    void deactivateShadows(Button b)
    {
        Shadow[] shadows = b.GetComponents<Shadow>();
        for (int i = 0; i < shadows.Length; i++)
        {
            shadows[i].enabled = false;
        }
    }








    public void show()
	{
		numberOfCoins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
		SP.hide ();
		Panel.SetActive(true);
	}
	public void hide()
	{
		SP.show ();
		Panel.SetActive(false);
	}
}
