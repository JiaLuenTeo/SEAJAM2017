using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManagerScript : MonoBehaviour {

	private static PrefabManagerScript mInstance = null;

	public static PrefabManagerScript Instance
	{
		get
		{
			// Singleton Implementation
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindWithTag("PrefabManager");

				if(tempObject == null)
				{
					Debug.LogError("PrefabManagerScript Does Not Exist In The Scene. Please Add It.");
				}
				else
				{
					mInstance = tempObject.GetComponent<PrefabManagerScript>();
				}
			}

			return mInstance;
		}
	}

	public GameObject gameManagerPrefab;
	public GameObject soundManagerPrefab;
}
