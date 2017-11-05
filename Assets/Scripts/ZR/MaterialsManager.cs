using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsManager : MonoBehaviour 
{
	//allows player to purchase the specific materials
	//TODO: Have a lock checking for tier leveling

	public string m_Material_Name;
	public int MaterialPrice = 1;
	public float MaterialAmount;
	public int AmountBundle = 1; // how many is acquired per purchase
	public float maxBarAmount = 20;

	RectTransform matBar;
	Text matName, matPrice, matAmount;

	public Sprite mEnable;
	public Sprite mDisable;
	public GameObject BuyButton;

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
	void Start () 
	{
		matName = gameObject.transform.Find ("IngredientName").GetComponent<Text>();
		matPrice = gameObject.transform.Find ("IngredientPrice").GetComponent<Text>();
		matAmount = gameObject.transform.Find ("CraftButton").Find("CraftButtonText").GetComponent<Text>();
		matBar = gameObject.transform.Find ("IngredientBar").GetComponent<RectTransform>();

		matName.text = m_Material_Name;
		matPrice.text = "RM " + MaterialPrice + " for " + AmountBundle;

		MaterialAmount = PlayerPrefs.GetInt(m_Material_Name + "_CM");

		updateNumber();
	}

	public void updateNumber()
	{
		MaterialAmount = PlayerPrefs.GetInt(m_Material_Name + "_CM");

		if (MaterialAmount <= 0)
		{
			matAmount.text = "BUY" ;
		}
		else if (MaterialAmount > 0)
		{
			matAmount.text = MaterialAmount.ToString();
		}
	}

	void updateBar()
	{
		if (MaterialAmount >= maxBarAmount)
		{
			matBar.localScale = new Vector3 (1,1,1);
		}
		if (MaterialAmount < maxBarAmount)
		{
			matBar.localScale = new Vector3((MaterialAmount/maxBarAmount),1,1);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerPrefs.GetInt ("Cash") < MaterialPrice) 
		{
			BuyButton.GetComponent<Image> ().sprite = mDisable;
		} 
		else 
		{
			BuyButton.GetComponent<Image> ().sprite = mEnable;
		}
		updateNumber();
		updateBar();
	}
}
