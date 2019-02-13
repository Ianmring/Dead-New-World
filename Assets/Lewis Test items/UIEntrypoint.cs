using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIEntrypoint : MonoBehaviour
{
    public GameObject clientVisual;
    public GameObject buildingSelection;
    // Start is called before the first frame update
    void Start()
    {
        buildingSelection.SetActive(false);
        clientVisual.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
