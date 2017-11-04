using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneySystem : MonoBehaviour 
{
	
	//public int CurrentCashAmount = 0;
	public Text Credits;

	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetInt ("FirstGame") == 0) 
		{
			Debug.Log ("Initial amount");
			PlayerPrefs.SetInt ("Cash", 500);
			PlayerPrefs.SetInt("FirstGame", 1);
		}

		//CurrentCashAmount = PlayerPrefs.GetInt ("Cash");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Credits.text = PlayerPrefs.GetInt ("Cash").ToString ();	
	}
}
