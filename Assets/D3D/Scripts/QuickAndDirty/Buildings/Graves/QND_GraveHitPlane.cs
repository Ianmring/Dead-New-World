using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QND_GraveHitPlane : MonoBehaviour {

    public Transform headstoneNode;
    public GraveState currentState;
    QNDGraveManager graveUIManager;

    void Awake ()
    {
        currentState = GraveState.Hole;
        graveUIManager = GetComponent<QNDGraveManager>();
    }

    public void OpenGraveMenu()
    {
        if(graveUIManager.graveManagerMenu.activeSelf != true)
            graveUIManager.graveManagerMenu.SetActive(true);

        PopulateGraveMenu();
    }

    public void CloseGraveMenu()
    {
        graveUIManager.graveManagerMenu.SetActive(false);
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

    public void PopulateGraveMenu()
    {

    }
}

public enum GraveState { Hole, Coffin, Filled }
