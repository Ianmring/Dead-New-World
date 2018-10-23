using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ValueStore : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    public string currentClientSelected;
    public string currentHeadstoneSelected;
    public D3D.Headstone currentHeadstone;


    public Text nameval;
    public Text Headval;



    
    public GameObject[] numofscenes;

    private void Awake()
    {
        currentClientSelected = null;
        currentHeadstone = null;

    }
   

    public void Restart()
    {
       

        currentClientSelected = null;
        currentHeadstone = null;
        currentHeadstoneSelected = null;
        numofscenes[0].SetActive(true);
        numofscenes[1].SetActive(false);
        numofscenes[2].SetActive(false);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        nameval.text = currentClientSelected;
        Headval.text = currentHeadstoneSelected;
       

    }
}
