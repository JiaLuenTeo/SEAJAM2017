using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

	public GameObject stockManagerSystemOBJ;
	public Image BarMeter;
	public Text craftText;

	public string ProductName; // crafted product
	public int ProductValue = 1;
	public float ProductLiquidity = 1.0f; // how many secs it will sold out
	public int CraftedAmount = 1;

	Text proName,proValue,proIngredName1,proIngredName2,proIngredName3;

	public bool Allowcrafting()
	{
		int counter = 0;
		foreach (CraftingMaterial_Properties materials in m_MaterialList) 
		{
			
			if (PlayerPrefs.GetInt (materials.Name + "_CM") > 0) 
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
			PlayerPrefs.SetInt (ProductName+"_ProdAmount", CraftedAmount);
			GameObject theProduct = GameObject.Find (ProductName);

			if ( theProduct!= null) 
			{ 
				Debug.Log (ProductName + " Existed!");
				theProduct.GetComponent<StockManagerSystem> ().CurrentAmount += CraftedAmount; // just add in amount
			} 
			else 
			{
				GameObject CraftedFood = Instantiate (stockManagerSystemOBJ);

				CraftedFood.name = ProductName;
				CraftedFood.GetComponent<StockManagerSystem> ().mLiquidityTimer = ProductLiquidity;
				CraftedFood.GetComponent<StockManagerSystem> ().ValueEarned_OverTime = ProductValue;

				CraftedFood.GetComponent<StockManagerSystem> ().CurrentAmount += CraftedAmount;
				CraftedFood.GetComponent<StockManagerSystem> ().StartCountDown = true;
				CraftedFood.GetComponent<StockManagerSystem> ().stockAmount = BarMeter;
				CraftedFood.GetComponent<StockManagerSystem> ().curAmount = craftText;
				theProduct = CraftedFood;
			}

			//TODO: Add data to UI DISPLAY AS WELL
			//TODO: Add UNLOCK SYSTEM


		}
	}
	// Use this for initialization
	void Start () 
	{
		proName = gameObject.transform.Find("RecipeName").GetComponent<Text>();
		proValue = gameObject.transform.Find("SellingPrice").GetComponent<Text>();

		craftText.text = "Craft";
		proName.text = ProductName;
		proValue.text = "RM " + ProductValue.ToString();
		for (int i = 0; i < m_MaterialList.Count;i++)
		{
			gameObject.transform.Find("Ingredient" + (i +1)).GetComponent<Text>().text = m_MaterialList[i].AmountRequired + " " + m_MaterialList[i].Name;
		}
		if (m_MaterialList.Count < 3)
		{
			gameObject.transform.Find("Ingredient3").GetComponent<Text>().text = "";
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.F4))
		{
			Debug.Log("ALL KEYS RESET");
			PlayerPrefs.DeleteAll();
		}
		#endif
	}
}
