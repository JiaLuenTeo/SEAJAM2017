﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTabScript : MonoBehaviour {

	public RectTransform recipeGO,ingredientGO,upgradeGO;
	public RectTransform recipeTOP,ingredientTOP,upgradeTOP;
	bool isOut;

	// Use this for initialization
	void Start () 
	{
		recipeSet();
	}

	void LateStart () 
	{
		recipeSet();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void recipeSet()
	{
		isOut = false;
		do
		{
			recipeGO.localPosition = Vector3.zero;
			recipeTOP.localPosition = Vector3.zero;
			ingredientGO.localPosition += Vector3.right;
			ingredientTOP.localPosition += Vector3.right;
			upgradeGO.localPosition += Vector3.right;
			upgradeTOP.localPosition += Vector3.right;
			if (ingredientGO.localPosition.x >= (ingredientGO.rect.max.x * 2) && upgradeGO.localPosition.x >= (upgradeGO.rect.max.x * 2))
			{
				isOut = true;
			}
		}while(!isOut);

	}

	public void ingredientSet()
	{
		isOut = false;
		do
		{
			recipeGO.localPosition += Vector3.right;
			ingredientGO.localPosition = Vector3.zero;
			upgradeGO.localPosition += Vector3.right;
			recipeTOP.localPosition += Vector3.right;
			ingredientTOP.localPosition = Vector3.zero;
			upgradeTOP.localPosition += Vector3.right;
			if (recipeGO.localPosition.x >= (recipeGO.rect.max.x * 2) && upgradeGO.localPosition.x >= (upgradeGO.rect.max.x * 2))
			{
				isOut = true;
			}
		}while(!isOut);
	}

	public void upgradeSet()
	{
		isOut = false;
		do
		{
			recipeGO.localPosition += Vector3.right;
			ingredientGO.localPosition += Vector3.right;
			upgradeGO.localPosition = Vector3.zero;
			recipeTOP.localPosition += Vector3.right;
			ingredientTOP.localPosition += Vector3.right;
			upgradeTOP.localPosition = Vector3.zero;
			if (recipeGO.localPosition.x >= (recipeGO.rect.max.x * 2) && ingredientGO.localPosition.x >= (ingredientGO.rect.max.x * 2))
			{
				isOut = true;
			}
		}while(!isOut);
	}


}
