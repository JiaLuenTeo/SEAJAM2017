using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGeneratorSystem : MonoBehaviour {

	public int MaxCounter = 15;
	private int currCounter = 0; // no. of counters to spawn resource.
	public int MaxResourceReward = 4; // max number of resources gives out
	public float TimeRequiredToCharge_Auto = 1f;
	public List<string> ResourceNames;
	private float CurrTime = 0f;


	//button func
	public void HastenSpeed()
	{
		currCounter -= 1;
	}

	void ProvideResources()
	{
		int randSeed=0;
		if (currCounter <= 0)
		{
			randSeed = Random.Range (0, ResourceNames.Count);
			PlayerPrefs.SetInt (ResourceNames[randSeed] + "_CM", PlayerPrefs.GetInt (ResourceNames[randSeed]  + "_CM") + Random.Range(1,MaxResourceReward));
			currCounter = MaxCounter;
		}
	}

	void OnEnable()
	{
		currCounter = MaxCounter;
	}
	// Use this for initialization
	void Start () 
	{
		currCounter = MaxCounter;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CurrTime += Time.deltaTime;
		if (CurrTime >= TimeRequiredToCharge_Auto)
		{
			CurrTime = 0f;
			ProvideResources ();
		}
	}
}
