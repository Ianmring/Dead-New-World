using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QNDGraveManager : MonoBehaviour {

    public Slider progressBarPrefab;
    public GameObject graveManagerMenu;
    public Canvas canvasRoot;

    Slider progressBar;

    void Awake()
    {
        progressBar = Instantiate(progressBarPrefab, canvasRoot.transform);
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        if (progressBar.enabled == true)
        {
            progressBar.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }

        if (graveManagerMenu.activeSelf == true)
        {

        }
    }

}
