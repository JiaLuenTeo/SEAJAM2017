using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StockManagerSystem : MonoBehaviour {


	//monitoring the stock's selling and adjust the stock amount and cash earned
	//These will be set upon crafted the products

	public float mLiquidityTimer;
	private float currentTimer = 0f;
	public int ValueEarned_OverTime;
	public float maxBarAmount = 20;
	public Image stockAmount;
	public Text curAmount;

	public Animator Gold;

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
				Gold.SetTrigger ("GainGold");
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

	void updateBar()
	{
		if (CurrentAmount >= maxBarAmount)
		{
			stockAmount.rectTransform.localScale = new Vector3 (1,1,1);
		}
		else if (CurrentAmount < maxBarAmount)
		{
			stockAmount.rectTransform.localScale = new Vector3( (CurrentAmount/maxBarAmount),1,1);
		}
	}

	void updateText()
	{
//		if(CurrentAmount == 0)
//		{
//			curAmount.text = "BUY";
//		}
	
		if (CurrentAmount > 0)
		{
			curAmount.text = CurrentAmount.ToString();
		}
	}

	void OnEnable()
	{
		Gold = GameObject.FindGameObjectWithTag ("Gold").GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		Gold = GameObject.FindGameObjectWithTag ("Gold").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (StartCountDown) 
		{
			updateText();
			updateBar();
			ProductSoldOverTime ();
		}
			
		
	}
}
