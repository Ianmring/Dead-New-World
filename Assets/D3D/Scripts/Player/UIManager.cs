using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public bool UIselected;
    public bool hideui;
    public void EnableDisableMenu(GameObject menu)
    {
        if (menu.activeSelf == false) menu.SetActive(true);
        else menu.SetActive(false);

    }

}
