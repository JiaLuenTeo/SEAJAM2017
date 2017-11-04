using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Entry : IComparable<Entry> {

	public string recipeName;
	public int ingredient1, ingredient2, ingredient3;
	public int sellingAmount;
	public int yieldAmount;

	public Entry (string _recipeName, int _ingredient1, int _ingredient2, int _ingredient3, int _sellingAmount, int _yieldAmount)
	{
		recipeName = _recipeName;
		ingredient1 = _ingredient1;
		ingredient2 = _ingredient2;
		ingredient3 = _ingredient3;
		sellingAmount = _sellingAmount;
		yieldAmount = _yieldAmount;
	}
		
	public int CompareTo( Entry other)
	{
		if (other == null)
			return -1;
		return other.sellingAmount - this.sellingAmount;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {





	}
}
