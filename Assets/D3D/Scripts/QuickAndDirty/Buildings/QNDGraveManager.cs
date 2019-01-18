using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using D3D;

public class QNDGraveManager : MonoBehaviour {

    public QNDGraveMenu graveManagerMenu;
    public Canvas canvasRoot;
    public GameObject filledGravePrefab;
    public GameObject coffinPrefab;
    public GameObject headstonePrefab;

    [HideInInspector]
    public QND_GraveHitPlane selectedGrave;

    void Awake()
    {
        //progressBar = Instantiate(progressBarPrefab, canvasRoot.transform);
        graveManagerMenu.gameObject.SetActive(false);
        selectedGrave = null;
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        /*if (progressBar.enabled == true)
            if(QNDPlayer.player.selectedGrave != null)
                progressBar.transform.position = Camera.main.WorldToScreenPoint(QNDPlayer.player.selectedGrave.transform.position);*/

        if (graveManagerMenu.gameObject.activeSelf == true)
        {

        }
    }

    public void SetGraveClient(QNDMenuButton buttonOptions)
    {
        if (buttonOptions.assignedObject.GetComponent<Clients>() != null)
            selectedGrave.currentClient = buttonOptions.assignedObject.GetComponent<Clients>();
        else selectedGrave.currentClient = null;
        graveManagerMenu.SetClientSelection(buttonOptions.assignedObjectName, buttonOptions.assignedObjectName);
        Debug.Log(selectedGrave.currentClient);
    }

    public void SetGraveCoffin(QNDMenuButton buttonOptions)
    {
        if (buttonOptions.assignedObject.GetComponent<Building>() != null)
            selectedGrave.currentCoffin = buttonOptions.assignedObject.GetComponent<Building>();
        else selectedGrave.currentCoffin = null;
        graveManagerMenu.SetCoffinSelection(buttonOptions.assignedObjectName, buttonOptions.assignedObjectSprite);
        Debug.Log(selectedGrave.currentCoffin);
    }

    public void SetGraveHeadstone(QNDMenuButton buttonOptions)
    {
        if (buttonOptions.assignedObject.GetComponent<Building>() != null)
            selectedGrave.currentHeadstone = buttonOptions.assignedObject.GetComponent<Building>();
        else selectedGrave.currentHeadstone = null;
        graveManagerMenu.SetHeadstoneSelection(buttonOptions.assignedObjectName, buttonOptions.assignedObjectSprite);
        Debug.Log(selectedGrave.currentHeadstone);
    }

    void OnClickGrave(QND_GraveHitPlane graveClicked)
    {
        SetCurrentGrave(graveClicked);
        graveClicked.ToggleGraveMenu();
    }

    public void SetCurrentGrave(QND_GraveHitPlane newGrave)
    {
        selectedGrave = newGrave;
        graveManagerMenu.gameObject.SetActive(true);
        if (newGrave.currentClient != null)
            graveManagerMenu.SetClientSelection(newGrave.currentClient.clientName.text, newGrave.currentClient.clientName.text);
        else { Debug.Log("Client not assigned!"); graveManagerMenu.SetClientSelection("Not Assigned", "Empty Grave"); }

        if (newGrave.currentCoffin != null)
            graveManagerMenu.SetCoffinSelection(newGrave.currentCoffin.buildingName, newGrave.currentCoffin.buildingImage);
        else { Debug.Log("Coffin not assigned!"); graveManagerMenu.SetCoffinSelection("No Selection", null); }

        if (newGrave.currentHeadstone != null)
            graveManagerMenu.SetHeadstoneSelection(newGrave.currentHeadstone.buildingName, newGrave.currentHeadstone.buildingImage);
        else { Debug.Log("Headstone not assigned!"); graveManagerMenu.SetHeadstoneSelection("No Selection", null); }
    }

    public void DeselectGrave()
    {
        graveManagerMenu.gameObject.SetActive(false);
        //selectedGrave = null;
    }

}
