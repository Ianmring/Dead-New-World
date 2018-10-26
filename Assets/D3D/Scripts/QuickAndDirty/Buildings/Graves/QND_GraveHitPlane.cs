using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QND_GraveHitPlane : MonoBehaviour {

    public Transform headstoneNode;
    public GraveState currentState;
    QNDGraveManager graveUIManager;

    void Start ()
    {
        currentState = GraveState.Hole;
        graveUIManager = QNDPlayer.player.GetComponent<QNDGraveManager>();
    }

    public void ToggleGraveMenu()
    {
        if (graveUIManager.graveManagerMenu.activeSelf != true)
        {
            QNDPlayer.player.selectedGrave = this;
            graveUIManager.graveManagerMenu.SetActive(true);
        }

        else
        {
            QNDPlayer.player.selectedGrave = null;
            graveUIManager.graveManagerMenu.SetActive(true);
        }
    }


    public void PlaceNewCoffin(Transform coffinPrefab)
    {
        Transform newCoffin = Instantiate(coffinPrefab, transform);
        currentState = GraveState.Coffin;
    }

    public void FillGrave(Transform filledGravePrefab)
    {
        Transform newFilledGrave = Instantiate(filledGravePrefab, transform);
        currentState = GraveState.Filled;
    }

    public void PlaceNewHeadstone(Transform headstonePrefab)
    {
        Transform newHeadstone = Instantiate(headstonePrefab, headstoneNode);
    }
}

public enum GraveState { Hole, Coffin, Filled }
