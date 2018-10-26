using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QNDGraveManager : MonoBehaviour {

    public GameObject graveManagerMenu;
    public Canvas canvasRoot;

    void Awake()
    {
        //progressBar = Instantiate(progressBarPrefab, canvasRoot.transform);
        graveManagerMenu.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        /*if (progressBar.enabled == true)
            if(QNDPlayer.player.selectedGrave != null)
                progressBar.transform.position = Camera.main.WorldToScreenPoint(QNDPlayer.player.selectedGrave.transform.position);*/

        if (graveManagerMenu.activeSelf == true)
        {

        }
    }

}
