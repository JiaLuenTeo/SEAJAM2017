using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	private static GameManagerScript mInstance = null;

	public static GameManagerScript Instance
	{
		get
		{
			// Singleton Implementation
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindWithTag("GameManager");

				if(tempObject == null)
				{
					tempObject = Instantiate(PrefabManagerScript.Instance.gameManagerPrefab, Vector3.zero, Quaternion.identity);
				}

				mInstance = tempObject.GetComponent<GameManagerScript>();
			}

			return mInstance;
		}
	}

	public Text MaterialA, MaterialB, MaterialC;
	public Text money;
	public float timeToSpawn;

	float moneyAmount = 1000;
	float spawnTime;
	int matA,matB,matC;

	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt("Cash", (int)moneyAmount);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//InitiateSpawn();
		ChangeText();
	}

	void InitiateSpawn()
	{
		spawnTime += Time.deltaTime;

		if(spawnTime >= timeToSpawn)
		{
			spawnTime = 0;
			spawnMat();
		}

	}

	void spawnMat()
	{
		int randNum = Random.Range(1,4);

		if (randNum == 1)
		{
			 matA += 1;
		}
		if (randNum == 2)
		{
			 matB += 1;
		}
		if (randNum == 3)
		{
			 matC += 1;
		}
	}

	void ChangeText()
	{
		money.text = "RM " + PlayerPrefs.GetInt("Cash");
//		MaterialA.text = "Material A : " + matA;
//		MaterialB.text = "Material B : " + matB;
//		MaterialC.text = "Material C : " + matC;
	}


}
