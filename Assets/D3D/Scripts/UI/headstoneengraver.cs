using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headstoneengraver : MonoBehaviour {

  public  D3D.Headstone currentheadstoneeng;

    cartinventory cart;
	// Use this for initialization
	void Start () {
        cart = FindObjectOfType<cartinventory>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
