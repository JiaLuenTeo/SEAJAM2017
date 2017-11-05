using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManagerScript : MonoBehaviour{

	private static SoundManagerScript mInstance = null;

	public static SoundManagerScript Instance
	{
		get
		{
			// Singleton Implementation
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindWithTag("SoundManager");

				if(tempObject == null)
				{
					tempObject = Instantiate(PrefabManagerScript.Instance.soundManagerPrefab, Vector3.zero, Quaternion.identity);
				}

				mInstance = tempObject.GetComponent<SoundManagerScript>();
			}

			return mInstance;
		}
	}

	public AudioSource BGM;
	public AudioSource coinSFX, buttonSFX;

	string currentActive;

	// Use this for initialization
	void Start () 
	{
		BGM.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!buttonSFX.isPlaying)
		{
			playButton();
		}

	}

	public void playCoin()
	{
		coinSFX.Play();
	}

	public void playButton()
	{
		if(EventSystem.current.currentSelectedGameObject.name != currentActive)
		{
			currentActive = EventSystem.current.currentSelectedGameObject.name;
			buttonSFX.Play();
		}
	}
}
