using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class headstoneengraver : MonoBehaviour {

  public  D3D.Headstone currentheadstoneeng;

    public HeadstoneMenu head;
    cartinventory cart;

   public GameObject menu;
	// Use this for initialization
	void Start () {
        cart = FindObjectOfType<cartinventory>();
       // head = FindObjectOfType<HeadstoneMenu>();
        Button bn1 = GetComponent<Button>();
        bn1.GetComponent<Button>().onClick.AddListener(EandDmen);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EandDmen()
    {

        if (menu.activeSelf == false) menu.SetActive(true);
        else menu.SetActive(false);

        GameObject headmen;
        headmen = Instantiate(menu, cart.HeadstoneholderCA.transform);


        headmen.GetComponent<HeadstoneMenu>().headstoneObject = currentheadstoneeng;

    }

}
