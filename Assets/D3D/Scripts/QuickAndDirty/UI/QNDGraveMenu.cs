using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QNDGraveMenu : MonoBehaviour {

    public Slider progressBarSlider;
    public List<GameObject> currentClientList;
    public List<GameObject> currentCoffinList;
    public List<GameObject> currentHeadstoneList;

    //creates new client in client list
    //contains functions for closing menu, switch current grave, updating progress bar, choosing options for menu

    void OnEnable()
    {
        if(QNDPlayer.player.selectedGrave != null)
            Camera.main.GetComponent<CameraController>().SetLockOn(QNDPlayer.player.selectedGrave.transform);
    }

    void OnDisable()
    {
        Camera.main.GetComponent<CameraController>().StopLockOn();
    }

}
