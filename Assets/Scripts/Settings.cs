using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    public static Settings instance;
    public GameObject Panel;
    StartPanel SP;
	public Text speedText;
 	

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
	public void speedSelect(float speed)
	{
		int iSpeed = (int)speed;
		print ("Speed select: " + speed);
		PlayerPrefs.SetInt ("speed", iSpeed);
		switch (iSpeed)
		{
			case 0:
				speedText.text = "Slow";
				break;
			case 1:
				speedText.text = "Normal";
				break;
			case 2:
				speedText.text = "Fast";
				break;
			case 3:
				speedText.text = "Faster";
				break;
			default:
				break;
		}
	}
	public void DeleteData(){
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene (0);
	}

}
