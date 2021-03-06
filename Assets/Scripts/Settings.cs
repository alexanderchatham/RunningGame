﻿using System.Collections;
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
	public Text sfxText;
	public GameObject ConfirmationPanel;
    public GameObject aboutmepanel;
    public Text ConfirmationText;
    public GameObject deleteYes;
	public Slider fslide;
    public Slider vslide;
	public Slider sfxslide;
    public int buffer = 1;

    public string ANDROID_RATE_URL;
    public string IOS_RATE_URL;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        ANDROID_RATE_URL = "market://details?id=com.AlexChatham.Hellscape";
		IOS_RATE_URL = "https://itunes.apple.com/us/app/apple-store/id1356756930?mt=8";
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
        sfxslide.value = PlayerPrefs.GetInt("SfxVolume", 20);
        InitializeSfx();
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
    public void InitializeSfx()
    {
        int i = PlayerPrefs.GetInt("SfxVolume", 20);
        GameObject.FindGameObjectWithTag("CoinSfx").GetComponent<AudioSource>().volume = ((float)(i * 5)) / 100;
    }

    public void SfxVolumeSelect(float speed)
	{
		int i = (int)speed;
		PlayerPrefs.SetInt("SfxVolume", i);
		print("Sfx Volume select: " + i);
        GameObject.FindGameObjectWithTag("CoinSfx").GetComponent<AudioSource>().volume =((float)(i*5)/100f);
        if (buffer > 0)
            buffer--;
        else
            GameObject.FindGameObjectWithTag("CoinSfx").GetComponent<AudioSource>().Play();
		sfxText.text = "" + i * 5;
	}

    public void DeleteData(){
        int ads = PlayerPrefs.GetInt("No Ads", 0);
		PlayerPrefs.DeleteAll ();
        PlayerPrefs.SetInt("No Ads", ads);
		SceneManager.LoadScene (0);
	}

	public void confirmation(){
        ConfirmationText.text = "Are you sure you would like to delete all of your data? (Does not effect No Ads)";
        ConfirmationPanel.SetActive (true);
        deleteYes.SetActive(true);
	}

    public void aboutme()
    {
        aboutmepanel.SetActive(true);
    }

    public void aboutmehide()
    {
        aboutmepanel.SetActive(false);
    }

    public void RateButton()
    {
#if UNITY_ANDROID
        Application.OpenURL(ANDROID_RATE_URL);
#elif UNITY_IOS
        Application.OpenURL(IOS_RATE_URL);
#endif
    }

	public void confirmationHide(){
		ConfirmationPanel.SetActive (false);
	}
}
