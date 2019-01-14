using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoclick : MonoBehaviour
{

    public LayerMask clickmak;
   public NPBehaveExampleEnemyAI enemy;

    // Start is called before the first frame update
    void Start()
    {
      //  enemy = GameObject.Find("Cube").GetComponent<NPBehaveExampleEnemyAI>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 clickpos = -Vector3.one;

            enemy.vec = clickpos;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast (ray, out hit, 100f, clickmak))
            {
                clickpos = hit.point;
            }

          //  Debug.Log(clickpos);
        }  
    }
}
