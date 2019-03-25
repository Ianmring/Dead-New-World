using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    public static ClientManager Instance = null;

    [SerializeField]
    private Text CurrentClientsText;

    [SerializeField]
    private Transform TextParentTransform;

    //Clients that are currently available for instantiation.
    [SerializeField]
    private List<Client> CurrentClients;

    //Clients that are going to be added via the "Accept Client" button
    //into the "CurrentClients" list.
    [SerializeField]
    private List<Client> ClientsToAdd = new List<Client>();

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion

        AddClientsToTheList();
    }

    //Function that adds all of the Client prefabs into the "ClientsToAdd" list
    //at the start of the game.
    private void AddClientsToTheList()
    {
        Object[] subListObjects = Resources.LoadAll("Prefabs", typeof(Client));

        foreach(Client client in subListObjects)
        {
            Client clientobject = (Client)client;

            ClientsToAdd.Add(clientobject);
        }
    }

    //Creates the "CurrentClientsText" prefab and parents itself to "TextParentTransform"
    //which is a vertical layout transform inside of the "Clients" panel.
    public void UpdateClients(int ClientIndex)
    {
        var TextObject = Instantiate(CurrentClientsText);

        TextObject.transform.SetParent(TextParentTransform, false);

        CurrentClientsText.text = ClientsToAdd[ClientIndex].ClientDetails();
    }

    public List<Client> GetCurrentClients
    {
        get
        {
            return CurrentClients;
        }
        set
        {
            CurrentClients = value;
        }
    }

    public List<Client> GetClientsToAdd
    {
        get
        {
            return ClientsToAdd;
        }
        set
        {
            ClientsToAdd = value;
        }
    }

    public Text GetCurrentClientText
    {
        get
        {
            return CurrentClientsText;
        }
        set
        {
            CurrentClientsText = value;
        }
    }
}
