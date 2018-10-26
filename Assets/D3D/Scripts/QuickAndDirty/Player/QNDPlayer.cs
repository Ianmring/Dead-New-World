using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QNDPlayer : MonoBehaviour {

    public Transform filledGravePrefab;
    public Transform coffinPrefab;
    public Transform headstonePrefab;

    [HideInInspector]
    public static QNDPlayer player;
    [HideInInspector]
    public QND_GraveHitPlane selectedGrave;

    Ray camRay;
    RaycastHit rayHit;
    QNDGraveManager graveManager;

    // Use this for initialization
    void Awake ()
    {
        if (player != null) DestroyImmediate(gameObject);
        else player = this;

        selectedGrave = null;
        graveManager = GetComponent<QNDGraveManager>();
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
                //graveClicked.PlaceNewCoffin(coffinPrefab);
                graveClicked.ToggleGraveMenu();
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

    public void SetCurrentGrave(QND_GraveHitPlane newGrave)
    {
        selectedGrave = newGrave;
        graveManager.graveManagerMenu.SetActive(true);
    }

    public void DeselectGrave()
    {
        graveManager.graveManagerMenu.SetActive(false);
        selectedGrave = null;
    }
}
