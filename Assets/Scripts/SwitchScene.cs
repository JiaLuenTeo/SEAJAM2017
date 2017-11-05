using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

	public Animator flashImage;
	public string nextScene;
	bool isDone;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		FindInput();
	}

	public void FindInput()
	{
		if (Input.touchCount > 0 || Input.GetMouseButton(0))
		{
			transistionStart();
		}
	}

	public void transistionStart()
	{
			SceneManager.LoadScene(nextScene);

	}
}
