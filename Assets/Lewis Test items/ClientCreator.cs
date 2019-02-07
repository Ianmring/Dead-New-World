using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientCreator : MonoBehaviour
{
    public Transform prefab;
    public int prefabNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        prefabNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(prefabNumber <= 0)
        {
            
            Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            prefabNumber++;
        }
    }
}
