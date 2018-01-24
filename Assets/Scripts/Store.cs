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
    public Button ice;

    private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start() 
	{
		SP = StartPanel.instance;
		selectCharacter (PlayerPrefs.GetInt("Character",0));
        checkUnlocked();
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
                cost = 20;
                break;
            case 2:
                cost = 30;
                break;
            case 3:
                cost = 40;
                break;
            default:
                break;
        }
        if (PlayerPrefs.GetInt("Coins", 0) >= cost || 1 == PlayerPrefs.GetInt("Character " + i + " unlocked", 0))
        {
            shadowFunction(i);
            unlockPlayer(i);
            if (0 == PlayerPrefs.GetInt("Character " + i + " unlocked", 0))
            {
                print("subtracting cost");
                numberOfCoins.text = (PlayerPrefs.GetInt("Coins", 0) - cost).ToString();
                int temp = PlayerPrefs.GetInt("Coins", 0) - cost;
                PlayerPrefs.SetInt("Coins", temp);
                PlayerPrefs.SetInt("Character " + i + " unlocked", 1);
            }
            else
            {
            }
            print("Selecting Character: " + i);
            PlayerPrefs.SetInt("Character", i);


            
        }
        else
        {
            print("Not enough coins");
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
                deactivateShadows(ice);
                break;
            case 1:
                activateShadows(fire);
                deactivateShadows(Orange);
                deactivateShadows(tree);
                deactivateShadows(ice);
                break;
            case 2:
                activateShadows(tree);
                deactivateShadows(fire);
                deactivateShadows(Orange);
                deactivateShadows(ice);
                break;
            case 3:
                activateShadows(ice);
                deactivateShadows(fire);
                deactivateShadows(Orange);
                deactivateShadows(tree);
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

    void checkUnlocked()
    {
        for(int i = 0; i <= 3; i++)
        {
            if(PlayerPrefs.GetInt("Character " + i + " unlocked", 0) == 1)
            {
                print("marking "+i+" unlocked");
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        fire.GetComponentInChildren<Text>().text = "Fire Guy\nUnlocked!";
                        break;
                    case 2:
                        tree.GetComponentInChildren<Text>().text = "Tree Guy\nUnlocked!";
                        break;
                    case 3:
                        ice.GetComponentInChildren<Text>().text = "Ice Guy\nUnlocked!";
                        break;
                }
            }
        }
    }

    void unlockPlayer(int i)
    {
        switch (i)
        {
            case 0:
                break;
            case 1:
                fire.GetComponentInChildren<Text>().text = "Fire Guy\nUnlocked!";
                break;
            case 2:
                tree.GetComponentInChildren<Text>().text = "Tree Guy\nUnlocked!";
                break;
            case 3:
                ice.GetComponentInChildren<Text>().text = "Ice Guy\nUnlocked!";
                break;
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
