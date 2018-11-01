using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QNDPlayer : MonoBehaviour {



    [HideInInspector]
    public static QNDPlayer player;
    [HideInInspector]
    public QNDGraveManager graveManager;

    Ray camRay;
    RaycastHit rayHit;

    // Use this for initialization
    void Awake ()
    {
        if (player != null) DestroyImmediate(gameObject);
        else player = this;

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
                    graveManager.SetCurrentGrave(rayHit.transform.gameObject.GetComponent<QND_GraveHitPlane>());
            }
        }
	}
}
