using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class StockManagerSystem : MonoBehaviour {


	//monitoring the stock's selling and adjust the stock amount and cash earned
	//These will be set upon crafted the products

	public float mLiquidityTimer;
	private float currentTimer = 0f;
	public int ValueEarned_OverTime;

	public int CurrentAmount = 0; // use addition instead of assign

	public bool StartCountDown = false;

	void ProductSoldOverTime()
	{
		int CurrentCash = PlayerPrefs.GetInt ("Cash");

		if (CurrentAmount > 0) 
		{
			currentTimer += Time.deltaTime;
			if (currentTimer >= mLiquidityTimer)
			{
				PlayerPrefs.SetInt ("Cash", CurrentCash + ValueEarned_OverTime);
				CurrentAmount -= 1;
				PlayerPrefs.SetInt (gameObject.name+"_ProdAmount", CurrentAmount);
				currentTimer = 0f;
			}

//			if (CurrentAmount <= 0) 
//			{
//				Debug.Log (gameObject.name + " CONSUMED");
//				Destroy (this.gameObject);
//				break;
//			}
		}

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (StartCountDown)
			ProductSoldOverTime ();
	}
}
