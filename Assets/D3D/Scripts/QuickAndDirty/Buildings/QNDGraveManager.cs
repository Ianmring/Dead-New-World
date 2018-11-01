using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        selectedGrave.SetClient(buttonOptions.assignedObject);
        graveManagerMenu.textClientSelection.text = buttonOptions.assignedObjectName;
        graveManagerMenu.textTitle.text = "Grave (" + buttonOptions.assignedObjectName + ")";
    }

    public void SetGraveCoffin(QNDMenuButton buttonOptions)
    {
        selectedGrave.PlaceNewCoffin(buttonOptions.assignedObject);
        graveManagerMenu.textCoffinSelection.text = buttonOptions.assignedObjectName;
        graveManagerMenu.imageCoffinSelection.sprite = buttonOptions.assignedObjectSprite;
    }

    public void SetGraveHeadstone(QNDMenuButton buttonOptions)
    {
        selectedGrave.PlaceNewHeadstone(buttonOptions.assignedObject);
        graveManagerMenu.textHeadstoneSelection.text = buttonOptions.assignedObjectName;
        graveManagerMenu.imageHeadstoneSelection.sprite = buttonOptions.assignedObjectSprite;
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
    }

    public void DeselectGrave()
    {
        graveManagerMenu.gameObject.SetActive(false);
        selectedGrave = null;
    }

}
