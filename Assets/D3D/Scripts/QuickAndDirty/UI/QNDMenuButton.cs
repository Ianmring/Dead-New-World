using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QNDMenuButton : MonoBehaviour {

    public GameObject assignedObject;
    public string assignedObjectName;
    public Sprite assignedObjectSprite;

    //[SerializeField]
    //private Text clientName;
    [SerializeField]
    private QNDGraveMenu parentMenu;
    private ValueStore store;

    private void Start()
    {
        //store = GameManager.gameManager.store;
    }

    /*public void AssignClient(string newText)
    {
        clientName.text = newText;
    }

    public void GetClient()
    {
        //store.currentClientSelected = clientName.text;
        //store.currentClient = currentClient;
    }*/
}
