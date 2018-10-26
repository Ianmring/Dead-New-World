using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using D3D;


//Optimization: Implement object pooling instead of destroying objects
public class HeadstoneMenu : MonoBehaviour {

    //public string currentClientSelected;

    List<GameObject> buttonList;
    int buttonPool;

    [SerializeField]
    GameObject buttonTemplate;
    [SerializeField]
    public Mod headstoneObject;

    [SerializeField]
    private GameManager man;

    ClientMana climan;
    private void Awake()
    {
        this.gameObject.SetActive(true);
        man = FindObjectOfType<GameManager>();
        buttonList = new List<GameObject>();
        climan = FindObjectOfType<ClientMana>();
    }

    private void OnEnable()
    {
        GenerateNewButtonList();
    }

    private void OnDisable()
    {
        EmptyList();
    }

    void GenerateNewButtonList()
    {
        EmptyList();

        for (int i = 0; i < climan.currentclients.Count; i++)
        {
            GameObject newButton = Instantiate(buttonTemplate);
            newButton.SetActive(true);
            newButton.GetComponent<HeadstoneMenuButton>().AssignClient(climan.currentclients[i].client);
            newButton.GetComponent<HeadstoneMenuButton>().currentcli = climan.currentclients[i];
            newButton.transform.SetParent(buttonTemplate.transform.parent, false);
            buttonList.Add(newButton);
        }
    }

    void EmptyList()
    {
        if (buttonList.Count > 0)
        {
            foreach (GameObject button in buttonList)
            {
                Destroy(button.gameObject);
            }

            buttonList.Clear();
        }
    }

    //public void GenerateNewHeadstone()
    //{
    //    /*if (currentClientSelected != null)
    //    {
    //        Mod newHeadstone = PlayerController.Player.assetManager.SetNewMod(headstoneObject);
    //        newHeadstone.GetComponent<Headstone>().SetEngraving(currentClientSelected);
    //    }

    //    EmptyList();
    //    currentClientSelected = null;*/
    //}

}
