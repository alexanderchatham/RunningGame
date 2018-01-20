using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberbuttons : MonoBehaviour {

	public static numberbuttons instance;

	public Sprite oneButton;
	public Sprite twoButton;
	public Sprite threeButton;
	public Sprite fourButton;
	public Sprite fiveButton;
	public Sprite SixButton;

	public static Sprite _oneButton;
	public static Sprite _twoButton;
	public static Sprite _threeButton;
	public static Sprite _fourButton;
	public static Sprite _fiveButton;
	public static Sprite _SixButton;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void Start()
	{

	_oneButton   =oneButton;
    _twoButton   =twoButton;
	_threeButton =threeButton;
	_fourButton  =fourButton;
	_fiveButton  =fiveButton;
    _SixButton   =SixButton;
	}

	public Sprite getButton(int i)
	{
		print ("Getting button");
		switch (i)
		{
			case 1:
				return _oneButton;
				break;
			case 2:
				return _twoButton;
				break;
			case 3:
				return _threeButton;
				break;
			case 4:
				return _fourButton;
				break;
			case 5:
				return _fiveButton;
				break;
			case 6:
				return _SixButton;
				break;
			default:
				return _oneButton;
				break;
		}
	}
}
