using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using D3D;

public class UIClient : MonoBehaviour
{
    [SerializeField]
    private Text clientName;

    [SerializeField]
    private ValueStore store;

    public Clients currentcli;

    

    // Start is called before the first frame update
    void Start()
    {
        store = FindObjectOfType<ValueStore>();
    }

    // Update is called once per frame
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