﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QNDGraveMenu : MonoBehaviour {

    public Text textClientSelection;
    public Text textTitle;
    public Image imageCoffinSelection;
    public Text textCoffinSelection;
    public Image imageHeadstoneSelection;
    public Text textHeadstoneSelection;

    public Slider progressBarSlider;
    public List<GameObject> currentClientList;
    public List<GameObject> currentCoffinList;
    public List<GameObject> currentHeadstoneList;

    //creates new client in client list
    //contains functions for closing menu, switch current grave, updating progress bar, choosing options for menu

    void OnEnable()
    {
        if(QNDPlayer.player.graveManager.selectedGrave != null)
            Camera.main.GetComponent<CameraController>().SetLockOn(QNDPlayer.player.graveManager.selectedGrave.transform);
    }

    void OnDisable()
    {
        Camera.main.GetComponent<CameraController>().StopLockOn();
    }

    public void SetClientSelection(string clientSelection, string title)
    {
        textClientSelection.text = clientSelection;
        textTitle.text = "Grave (" + title + ")";
    }

    public void SetCoffinSelection(string coffinSelection, Sprite coffinSprite)
    {
        textCoffinSelection.text = coffinSelection;
        imageCoffinSelection.sprite = coffinSprite;
    }

    public void SetHeadstoneSelection(string headstoneSelection, Sprite headstoneSprite)
    {
        textHeadstoneSelection.text = headstoneSelection;
        imageHeadstoneSelection.sprite = headstoneSprite;
    }
}
