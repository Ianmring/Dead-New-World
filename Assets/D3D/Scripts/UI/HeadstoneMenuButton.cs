using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using D3D;

public class HeadstoneMenuButton : MonoBehaviour {

    [SerializeField]
    private Text clientName;

    [SerializeField]
    private HeadstoneMenu parentMenu;

    public Clients currentcli;

    [SerializeField]
    private ValueStore store;

    private void Start()
    {
        store = FindObjectOfType<ValueStore>();
    }
    public void AssignClient(string newText)
    {
        clientName.text = newText;
    }

    public void GetClient()
    {
        store.currentClientSelected = clientName.text;
        store.currentClient = currentcli;
    }

}
