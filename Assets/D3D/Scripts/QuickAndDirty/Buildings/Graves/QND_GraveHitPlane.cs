using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QND_GraveHitPlane : MonoBehaviour {

    public Transform headstoneNode;
    public GraveState currentState;

    void Awake ()
    {
        currentState = GraveState.Hole;
    }

    public void OpenCoffinSelection()
    {
        //opens coffin menu
    }

    public void OpenHeadstoneSelection()
    {
        //opens headstone menu
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
