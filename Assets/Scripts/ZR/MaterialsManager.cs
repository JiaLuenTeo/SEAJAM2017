using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsManager : MonoBehaviour 
{
	//allows player to purchase the specific materials
	//TODO: Have a lock checking for tier leveling


	public string m_Material_Name;
	public int MaterialPrice = 1;
	public int AmountBundle = 1; // how many is acquired per purchase
	//set in game obj button
	public void PurchaseMaterial()
	{
		if (PlayerPrefs.GetInt ("Cash") > MaterialPrice) 
		{
			PlayerPrefs.SetInt (m_Material_Name + "_CM", PlayerPrefs.GetInt (m_Material_Name + "_CM") + AmountBundle);
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - MaterialPrice);
			Debug.Log (m_Material_Name + "Acquired: " + PlayerPrefs.GetInt (m_Material_Name + "_CM"));
		}

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
