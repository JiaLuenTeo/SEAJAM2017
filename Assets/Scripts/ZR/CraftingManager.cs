using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class CraftingMaterial_Properties
{
	public string Name;
	public int AmountRequired;
}
public class CraftingManager : MonoBehaviour 
{
	//Will be attach to each individual obj and each has their own material
	public List<CraftingMaterial_Properties> m_MaterialList;

	public string ProductName; // crafted product
	public int CraftedAmount = 1;

	public bool Allowcrafting()
	{
		int counter = 0;
		foreach (string materials in m_MaterialList) 
		{
			if (PlayerPrefs.GetInt (materials + "_CM") > 0) 
			{
				counter += 1;
			}
		}

		if(counter == m_MaterialList.Count)
		{
			Debug.Log ("ALLOW CRAFTING " + ProductName);
			return true;
		}
		else
		{
			Debug.Log ("CANT CRAFT " + ProductName);
			return false;
		}
	}


	public void Craft_Recipe() // call this at button
	{
		if (Allowcrafting ()) 
		{
			PlayerPrefs.SetInt (ProductName, CraftedAmount);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
