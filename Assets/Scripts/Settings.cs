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
    public Text volumeText;
	public GameObject ConfirmationPanel;
    public Text ConfirmationText;
    public GameObject deleteYes;
	public Slider fslide;
    public Slider vslide;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        SP = StartPanel.instance;
		fslide.value = PlayerPrefs.GetInt("speed", 1);
		switch ((int)fslide.value)
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
        vslide.value = PlayerPrefs.GetInt("Volume", 20);
        VolumeSelect(PlayerPrefs.GetInt("Volume", 20));
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
        VolumeSelect(PlayerPrefs.GetInt("Volume",20));
	}

   public void InitializeVolume()
    {
        int i = PlayerPrefs.GetInt("Volume", 20);
        GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().volume = ((float)(i*5))/100;
    }

    public void VolumeSelect(float speed)
    {
        int i = (int)speed;
        print("Volume select: " + i);
        PlayerPrefs.SetInt("Volume", i);
        volumeText.text = "" + i * 5;
        InitializeVolume();
    }
    public void DeleteData(){
       int ads = PlayerPrefs.GetInt("No Ads", 0);
		PlayerPrefs.DeleteAll ();
        //PlayerPrefs.SetInt("No Ads", ads);
		SceneManager.LoadScene (0);
	}

	public void confirmation(){
        ConfirmationText.text = "Are you sure you would like to delete all of your data? (Does not effect No Ads)";
        ConfirmationPanel.SetActive (true);
        deleteYes.SetActive(true);
	}

	public void confirmationHide(){
		ConfirmationPanel.SetActive (false);
	}
}
