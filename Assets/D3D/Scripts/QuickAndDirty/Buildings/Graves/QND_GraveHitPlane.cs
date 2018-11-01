using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QND_GraveHitPlane : MonoBehaviour {

    public Transform headstoneNode;
    public GraveState currentState;

    QNDGraveManager graveUIManager;
    GameObject currentClient;
    GameObject currentCoffin;
    GameObject currentHeadstone;

    void Start ()
    {
        currentState = GraveState.Hole;
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

    public void PlaceNewCoffin(GameObject coffinPrefab)
    {
        if (currentCoffin != null) Destroy(currentCoffin);
        if (coffinPrefab != null) currentCoffin = Instantiate(coffinPrefab, transform);
        currentState = GraveState.Coffin;
    }

    public void FillGrave(GameObject filledGravePrefab)
    {
        GameObject newFilledGrave = Instantiate(filledGravePrefab, transform);
        currentState = GraveState.Filled;
    }

    public void PlaceNewHeadstone(GameObject headstonePrefab)
    {
        if (currentHeadstone != null) Destroy(currentHeadstone);
        //if (headstonePrefab != null) currentHeadstone = Instantiate(headstonePrefab, headstoneNode);
    }
}

public enum GraveState { Hole, Coffin, Filled }
