using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressHandler : MonoBehaviour {

    [SerializeField]
    Slider progressBar;
    [SerializeField]
    Button progressButton;

    public void ProgressSlider(float rate)
    {
        progressBar.value += rate;
        //if(progressBar >= progressBar.maxValue)
    }

    public void SetInteractButton(bool setInteract)
    {
        progressButton.interactable = setInteract;
    }

    public void SetActiveButton(bool setActive)
    {
        progressButton.gameObject.SetActive(setActive);
    }

    public void SetActiveSlider(bool setActive)
    {
        progressBar.gameObject.SetActive(setActive);
    }

}
