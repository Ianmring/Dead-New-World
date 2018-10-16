using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public List<string> clientList;
    //public AssetPlacementManager assetManager;

    private static PlayerController _player;
    public static PlayerController Player {
        get {
            if (_player == null)
            {
                _player = FindObjectOfType<PlayerController>();

                if(FindObjectsOfType<PlayerController>().Length > 1)
                {
                    foreach(PlayerController p in FindObjectsOfType<PlayerController>())
                    {
                        Destroy(p.gameObject);
                    }
                }

                return _player;
            }

            return _player;
        }

    }

    private void Start()
    {
        //assetManager = GetComponent<AssetPlacementManager>();
        //clientList = new List<string>();

        //assetManager.InitializeManager();
    }

    private void Update()
    {
        //assetManager.SelectionHandler();
    }

}
