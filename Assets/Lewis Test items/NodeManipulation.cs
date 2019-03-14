using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManipulation : MonoBehaviour
{
    float nodeDistance = 0.0f;
    GridGraph node;

    // Start is called before the first frame update
    void Start()
    {
       node = AstarPath.active.data.gridGraph;
    }

    // Update is called once per frame
    void Update()
    {
        node.GetNodes(nodeDistance =>
        {
            Debug.Log("I found many" + (Vector3)nodeDistance.position);
        });
    }
}
