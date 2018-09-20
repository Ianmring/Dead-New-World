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

    public void AssignClient(string newText)
    {
        clientName.text = newText;
    }

    public void GetClient()
    {
        parentMenu.currentClientSelected = clientName.text;
    }

}
