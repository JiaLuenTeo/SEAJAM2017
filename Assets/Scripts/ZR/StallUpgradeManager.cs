using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class StallTier{

	public Sprite TierPic;
	public List<GameObject> Recipes; // recipes that can be acquired in the tier

}




public class StallUpgradeManager : MonoBehaviour {

	public List<StallTier> stallTier;
	Text buttonTxt;
	public Image StallPic;
	//button func
	public void UpgradeStall(int cost)
	{
		if (PlayerPrefs.GetInt ("Stall_Tier") < 2) {
			if (PlayerPrefs.GetInt ("Cash") >= cost) 
			{
				Debug.Log ("STALL Upgrade purchased");
				PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - cost);
				PlayerPrefs.SetInt ("Stall_Tier", PlayerPrefs.GetInt ("Stall_Tier") + 1);
				TierCheck ();
				//TODO: Change stall visual
			} 
			else 
			{
				Debug.Log ("NO CASH!");
			}
		} 
		else 
		{
			Debug.Log ("MAX TIER!");

			//TODO: Add notification
		}


	}

	void TierCheck()
	{
		for (int i = 0; i < stallTier.Count; i++) 
		{
			if (i > PlayerPrefs.GetInt ("Stall_Tier")) {
				foreach (GameObject trecipe in stallTier[i].Recipes) {
					trecipe.SetActive (false);
				}
			}
			else 
			{
				foreach (GameObject trecipe in stallTier[i].Recipes) {
					trecipe.SetActive (true);
				}
			}
		}
	}

	void ChangeText()
	{
		if (PlayerPrefs.GetInt("Stall_Tier") < stallTier.Count-1 )
		{
			buttonTxt.text = "Upgrade Stall" + "\n" + "Tier Level : " + PlayerPrefs.GetInt("Stall_Tier");
		}
		else if (PlayerPrefs.GetInt("Stall_Tier") == stallTier.Count-1)
		{
			
			buttonTxt.text = "Upgrade Stall" + "\n" + "Tier Level : " + "MAX";
		}

	}

	// Use this for initialization
	void Start () 
	{
		buttonTxt = gameObject.transform.Find("UpgradeStall").Find("Text").GetComponent<Text>();
		TierCheck ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		StallPic.sprite = stallTier [PlayerPrefs.GetInt ("Stall_Tier")].TierPic;
		ChangeText();
	}
}
