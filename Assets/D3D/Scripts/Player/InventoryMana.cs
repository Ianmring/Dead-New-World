using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryMana : MonoBehaviour {

    // Use this for initialization

    public List<GameObject> headstoneList = new List<GameObject>();
    public List<Coffin> CoffinList = new List<Coffin>();

     GameManager man;
    public GameObject Headstoneholder;
    public GameObject coffinholder;

    void Awake () {
        man = FindObjectOfType<GameManager>();
        refreshheadstonelist();
        refreshcoffinlist();
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    public void refreshheadstonelist()
    {
        foreach (GameObject headlist in headstoneList)
        {
            GameObject head;
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
    public void refreshclientlist()
    {
        foreach (var client in man.openclients)
        {
            
        }
    }
}
