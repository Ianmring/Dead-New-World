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
    private Button thisButton;
    private Image thisImage;

    private void Start()
    {
        //store = GameManager.gameManager.store;

        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();
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

    public void EnableSelection()
    {
        thisButton.interactable = true;
        if (thisImage != null) thisImage.color = Color.white;
    }

    public void DisableSelection()
    {
        thisButton.interactable = false;
        if (thisImage != null) thisImage.color = Color.gray;
    }
}
