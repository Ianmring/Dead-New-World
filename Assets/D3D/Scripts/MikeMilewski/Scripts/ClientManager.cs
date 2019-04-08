using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    public static ClientManager Instance = null;

    [SerializeField]
    private Button CurrentClientsButton;

    [SerializeField]
    private GameObject NewClientRequestMenu, ClientInfoMenu;

    [SerializeField]
    private Transform ButtonParentTransform;

    [SerializeField]
    private Text ClientInfoText;

    [SerializeField]
    private Client clientObject;

    [SerializeField]
    private List<ClientData> data;

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

    //Function that adds all of the ClientData into the "Data" list
    //at the start of the game and assigns a random ClientData to each
    //Client in the list.
    private void AddClientsToTheList()
    {
        Object[] clientData = Resources.LoadAll("ClientData", typeof(ClientData));

        foreach (ClientData cd in clientData)
        {
            data.Add(cd);
        }

        for (int i = 0; i < data.Count; i++)
        {
            ClientsToAdd.Add(clientObject);
            ClientsToAdd[i].GetClientData = data[Random.Range(0, data.Count)];
        }
    }

    //Creates the "CurrentClientsText" prefab and parents itself to "TextParentTransform"
    //which is a vertical layout transform inside of the "Clients" panel.
    public void UpdateClients(int ClientIndex)
    {
        var ClientButton = Instantiate(CurrentClientsButton);

        ClientButton.transform.SetParent(ButtonParentTransform, false);

        CurrentClientsButton.GetComponentInChildren<Text>().text = ClientsToAdd[ClientIndex].ClientMenuDetails();
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

    public GameObject GetNewClientRequestMenu
    {
        get
        {
           return NewClientRequestMenu;
        }
        set
        {
            NewClientRequestMenu = value;
        }
    }
    
    public GameObject GetClientInfoMenu
    {
        get
        {
            return ClientInfoMenu;
        }
        set
        {
            ClientInfoMenu = value;
        }
    }

    public Text GetClientInfoText
    {
        get
        {
            return ClientInfoText;
        }
        set
        {
            ClientInfoText = value;
        }
    }
}
