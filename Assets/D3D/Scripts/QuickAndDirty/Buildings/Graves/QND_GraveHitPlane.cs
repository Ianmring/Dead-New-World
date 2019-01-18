using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using D3D;

public class QND_GraveHitPlane : MonoBehaviour {

    public Clients currentClient
    {
        set
        {
            if (_currentClient != null) Destroy(_currentClient);
            if (value != null) _currentClient = Instantiate(value, transform);
        }
        get { return _currentClient; }
    }

    public Building currentCoffin
    {
        set { _currentCoffin = value; }
        get { return _currentCoffin; }
    }

    public Building currentHeadstone
    {
        set { _currentHeadstone = value; }
        get { return _currentHeadstone; }
    }

    public Transform headstoneNode;
    public GraveState currentState;

    QNDGraveManager graveUIManager;
    QNDBuildingTask currentTask;
    Clients _currentClient;
    Building _currentCoffin;
    Building _currentHeadstone;

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

    public void PlaceNewCoffin()
    {
        Building newCoffin = Instantiate(currentCoffin, transform);
        //currentState = GraveState.Coffin;
    }

    public void PlaceNewHeadstone()
    {
        Building newHeadstone = Instantiate(currentHeadstone, headstoneNode);
    }

    public void FillGrave(GameObject filledGravePrefab)
    {
        GameObject newFilledGrave = Instantiate(filledGravePrefab, transform);
        //currentState = GraveState.Filled;
    }
}

public enum GraveState { state_empty, state_locked, state_funeral, state_complete }
//state_empty = hole, no selections made
//state_locked = selections locked in, engraving headstone
//state_engraved = headstone engraved, waiting for funeral
//state_complete = funeral complete, grave buried successfully
