using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class headstoneobj : MonoBehaviour {

    bool isabletocheckout;

    public D3D.Headstone currentheadstone;

    cartinventory cart;

    public GameObject carthead;

    HeadstoneMenu man;

    Button thisbutton;
	// Use this for initialization
	void Start () {
        cart = FindObjectOfType<cartinventory>();
        thisbutton = GetComponent<Button>();
        man = FindObjectOfType<HeadstoneMenu>();
        thisbutton.onClick.AddListener(addedtocart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
    public void addedtocart()
    {
        GameObject cartheadtemp;
        cartheadtemp = Instantiate(carthead, cart.HeadstoneholderCA.transform);
        cartheadtemp.transform.SetParent(cart.HeadstoneholderCA.gameObject.transform);

  cartheadtemp.GetComponent<headstoneengraver>().currentheadstoneeng = currentheadstone;
        cartheadtemp.GetComponent<headstoneengraver>().head = man;

        cart.headstonecart.Insert(0, cartheadtemp.GetComponent<headstoneengraver>());

    }
}
