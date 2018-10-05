using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryMana : MonoBehaviour {

    // Use this for initialization

    public List<D3D.Headstone> headstoneList = new List<D3D.Headstone>();
    public List<Coffin> CoffinList = new List<Coffin>();


    public GameObject Headstoneholder;
    public GameObject coffinholder;

    void Start () {
        refreshheadstonelist();
        refreshcoffinlist();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void refreshheadstonelist()
    {
        foreach (D3D.Headstone headlist in headstoneList)
        {
            D3D.Headstone head;
            head = Instantiate(headlist, this.transform);
            head.transform.SetParent(Headstoneholder.gameObject.transform);

        }
    }
    public void refreshcoffinlist()
    {
        foreach (Coffin coffinlist in CoffinList)
        {
            Coffin coffin;
            coffin = Instantiate(coffinlist, this.transform);
            coffin.transform.SetParent(coffinholder.gameObject.transform);

        }
    }
}
