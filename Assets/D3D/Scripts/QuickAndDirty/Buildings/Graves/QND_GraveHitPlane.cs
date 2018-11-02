using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QND_GraveHitPlane : MonoBehaviour {

    public Transform headstoneNode;
    public GraveState currentState;

    QNDGraveManager graveUIManager;
    QNDBuildingTask currentTask;
    GameObject currentClient;
    GameObject currentCoffin;
    GameObject currentHeadstone;

    void Start ()
    {
        currentState = GraveState.state_empty;
        currentTask = null;
        graveUIManager = QNDPlayer.player.GetComponent<QNDGraveManager>();
    }

    public void ToggleGraveMenu()
    {
        if (graveUIManager.graveManagerMenu.gameObject.activeSelf != true)
        {
            QNDPlayer.player.graveManager.selectedGrave = this;
            graveUIManager.graveManagerMenu.gameObject.SetActive(true);
        }

        else
        {
            QNDPlayer.player.graveManager.selectedGrave = null;
            graveUIManager.graveManagerMenu.gameObject.SetActive(true);
        }
    }

    public void SetClient(GameObject newClient)
    {
        if (currentClient != null) Destroy(currentClient);
        if (newClient != null) currentClient = Instantiate(newClient, transform);
    }

    public void PlaceNewCoffin()
    {
        GameObject newCoffin = Instantiate(currentCoffin, transform);
        //currentState = GraveState.Coffin;
    }

    public void PlaceNewHeadstone()
    {
        GameObject newHeadstone = Instantiate(currentHeadstone, headstoneNode);
    }

    public void FillGrave(GameObject filledGravePrefab)
    {
        GameObject newFilledGrave = Instantiate(filledGravePrefab, transform);
        //currentState = GraveState.Filled;
    }

    public void SetCoffin(GameObject coffinPrefab)
    {
        currentCoffin = coffinPrefab;
    }

    public void SetHeadstone(GameObject headstonePrefab)
    {
        currentHeadstone = headstonePrefab;
    }
}

public enum GraveState { state_empty, state_locked, state_funeral, state_complete }
//state_empty = hole, no selections made
//state_locked = selections locked in, engraving headstone
//state_engraved = headstone engraved, waiting for funeral
//state_complete = funeral complete, grave buried successfully
