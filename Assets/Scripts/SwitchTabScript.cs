using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTabScript : MonoBehaviour {

	public GameObject recipeGO,ingredientGO,upgradeGO;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void recipeSet()
	{
		recipeGO.SetActive(true);
		ingredientGO.SetActive(false);
		upgradeGO.SetActive(false);
	}

	public void ingredientSet()
	{
		recipeGO.SetActive(false);
		ingredientGO.SetActive(true);
		upgradeGO.SetActive(false);
	}

	public void upgradeSet()
	{
		recipeGO.SetActive(false);
		ingredientGO.SetActive(false);
		upgradeGO.SetActive(true);
	}


}
