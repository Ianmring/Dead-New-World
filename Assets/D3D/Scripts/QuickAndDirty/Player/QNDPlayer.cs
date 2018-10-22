using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QNDPlayer : MonoBehaviour {

    public Transform filledGravePrefab;
    public Transform coffinPrefab;
    public Transform headstonePrefab;

    Ray camRay;
    RaycastHit rayHit;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camRay, out rayHit))
            {
                if (rayHit.transform.gameObject.GetComponent<QND_GraveHitPlane>() != null)
                    OnClickGrave(rayHit.transform.gameObject.GetComponent<QND_GraveHitPlane>());
            }
        }
	}

    void OnClickGrave(QND_GraveHitPlane graveClicked)
    {
        switch (graveClicked.currentState)
        {
            case GraveState.Hole:
                graveClicked.PlaceNewCoffin(coffinPrefab);
                break;
            case GraveState.Coffin:
                graveClicked.FillGrave(filledGravePrefab);
                break;
            case GraveState.Filled:
                graveClicked.PlaceNewHeadstone(headstonePrefab);
                break;
            default:
                Debug.Log("No state match");
                break;
        }
    }
}
