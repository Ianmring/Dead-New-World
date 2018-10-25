using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class headstoneobj : MonoBehaviour {

    bool isabletocheckout;

    public D3D.Headstone currentheadstone;

    ValueStore store;
    cartinventory cart;

   // public GameObject carthead;

    HeadstoneMenu man;

    Button thisbutton;

	// Use this for initialization
	void Start () {
        store = FindObjectOfType<ValueStore>();
        cart = FindObjectOfType<cartinventory>();
        thisbutton = GetComponent<Button>();
        man = FindObjectOfType<HeadstoneMenu>();
        thisbutton.onClick.AddListener(StoreHead);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
    public void StoreHead()
    {
        store.currentHeadstone = currentheadstone;
        store.currentHeadstoneSelected = currentheadstone.ToString();
        store.numofscenes[1].SetActive(false);
        store.numofscenes[2].SetActive(true);



    }
}
