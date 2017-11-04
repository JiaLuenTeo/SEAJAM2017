using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecipeTemplate
{
	public int ingredient1, ingredient2, ingredient3;
	public int yieldAmount;

	public RecipeTemplate(int _ingredient1, int _ingredient2, int _ingredient3, int _yieldAmount)
	{
		ingredient1 = _ingredient1;
		ingredient2 = _ingredient2;
		ingredient3 = _ingredient3;
		yieldAmount = _yieldAmount;
	}

}

public class RecipeManagerScript : MonoBehaviour {

	private static RecipeManagerScript mInstance = null;

	public static RecipeManagerScript Instance
	{
		get
		{
			// Singleton Implementation
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindWithTag("RecipeManager");

				if(tempObject == null)
				{
					tempObject = Instantiate(PrefabManagerScript.Instance.recipeManagerPrefab, Vector3.zero, Quaternion.identity);
				}

				mInstance = tempObject.GetComponent<RecipeManagerScript>();
			}

			return mInstance;
		}
	}

	public List<RecipeTemplate> RecipesList = new List<RecipeTemplate>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
