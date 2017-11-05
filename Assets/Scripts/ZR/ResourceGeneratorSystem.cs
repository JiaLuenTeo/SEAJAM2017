using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class MachineTier{

	public int MaxCounter = 15;
	public int MaxResourceReward = 4; // max number of resources gives out
	public float TimeRequiredToCharge_Auto = 6f;
	public List<string> ResourceNames; // resources that can be acquired in the tier
	//TODO: ADD SPRITE IMAGE CHANGE
}



public class ResourceGeneratorSystem : MonoBehaviour {

	public List<MachineTier> mMachineTier;


	private float CurrTime = 0f;
	private int currCounter = 0; // no. of counters to spawn resource.

	Text buttonTxt;

	//button func
	public void HastenSpeed()
	{
		currCounter -= 1;
	}



	//button func
	public void UpgradeMachine(int cost)
	{
		if (PlayerPrefs.GetInt ("Machine_Tier") < 2) {
			if (PlayerPrefs.GetInt ("Cash") >= cost) 
			{
				Debug.Log ("Upgrade purchased");
				PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - cost);
				PlayerPrefs.SetInt ("Machine_Tier", PlayerPrefs.GetInt ("Machine_Tier") + 1);
				//TODO: Change machine visual
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


	void ProvideResources()
	{
		int randSeed=0;
		int randAmount = 0;
		if (currCounter <= 0)
		{
			randSeed = UnityEngine.Random.Range (0, mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].ResourceNames.Count);
			randAmount = UnityEngine.Random.Range (1, mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].MaxResourceReward);

			PlayerPrefs.SetInt (mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].ResourceNames[randSeed] + "_CM", 
				PlayerPrefs.GetInt (mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].ResourceNames[randSeed]  + "_CM") 
				+ UnityEngine.Random.Range(1,mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].MaxResourceReward) + randAmount);
			
			currCounter = mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].MaxCounter;
		}
	}

	void OnEnable()
	{
		currCounter = mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].MaxCounter;
	}

	void ChangeText()
	{
		if (PlayerPrefs.GetInt("Machine_Tier") < mMachineTier.Count - 1)
		{
			buttonTxt.text = "Material Generator" + "\n" + "Tier Level : " + PlayerPrefs.GetInt("Machine_Tier");
		}
		else if (PlayerPrefs.GetInt("Machine_Tier") == mMachineTier.Count - 1)
		{

			buttonTxt.text = "Material Generator" + "\n" + "Tier Level : " + "MAX";
		}
	}
	// Use this for initialization
	void Start () 
	{
		Debug.Log (PlayerPrefs.GetInt("Machine_Tier") + "=" +  mMachineTier.Count);
		buttonTxt = gameObject.transform.Find("UpgradeMachine").Find("Text").GetComponent<Text>();
		currCounter = mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].MaxCounter;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangeText();
		CurrTime += Time.deltaTime;
		if (CurrTime >= mMachineTier[PlayerPrefs.GetInt ("Machine_Tier") ].TimeRequiredToCharge_Auto)
		{
			CurrTime = 0f;
			ProvideResources ();
		}
	}
}
