using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;


public class ClientAcceptButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject clientVisual;
    public GameObject buildingSelection;
   
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(pointerEventData.button == PointerEventData.InputButton.Right)
        {
            buildingSelection.SetActive(true);
            clientVisual.SetActive(false);
            Debug.Log("Im being clicked");

        }
        
    }

   
}
