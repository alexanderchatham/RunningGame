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
	public GameObject ConfirmationPanel;
	public Slider slide;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        SP = StartPanel.instance;
		slide.value = PlayerPrefs.GetInt("speed", 0);
		switch ((int)slide.value)
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
        int ads = PlayerPrefs.GetInt("No Ads", 0);
		PlayerPrefs.DeleteAll ();
        PlayerPrefs.SetInt("No Ads", ads);
		SceneManager.LoadScene (0);
	}

	public void confirmation(){
		ConfirmationPanel.SetActive (true);
	}

	public void confirmationHide(){
		ConfirmationPanel.SetActive (false);
	}
}
