using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    public static ClientManager Instance = null;

    [SerializeField]
    private int clientIndex;

    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private Button CurrentClientsButton;

    [SerializeField]
    private GameObject NewClientRequestMenu, ClientDetailsMenu;

    [SerializeField]
    private GameObject LastSelectedObject = null; //Always leave this as null.

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
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion

        AddClientsToTheList();
    }

    //Function that adds all of the ClientData into the "Data" list
    //at the start of the game and assigns a ClientData to each
    //Client in the list in order of the index.
    private void AddClientsToTheList()
    {
        int index = 0;
        Object[] clientData = Resources.LoadAll("ClientData", typeof(ClientData));

        foreach (ClientData cd in clientData)
        {
            data.Add(cd);
        }
        for (int i = index; i <= clientData.Length - 1; i++)
        {
            ClientsToAdd.Add(clientObject);
            ClientsToAdd[i].GetClientData = data[index];
            //Debug.Log(ClientsToAdd[i].GetClientData = data[index]);
            index++;
        }
    }

    //Creates the "CurrentClientsButton" prefab and parents itself to "ButtonParentTransform"
    //which is a vertical layout transform inside of the "Clients" panel.
    public void UpdateClients(int ClientIndex)
    {
        var clientBtn = Instantiate(CurrentClientsButton);

        clientIndex++;
        clientBtn.GetComponent<ClientButton>().GetClientIndex = clientIndex;

        clientBtn.transform.SetParent(ButtonParentTransform, false);

        clientBtn.GetComponentInChildren<Text>().text = ClientsToAdd[ClientIndex].ClientMenuDetails();
    }

    #region Properties
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

    public List<ClientData> GetClientData
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
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
    
    public GameObject GetClientDetailsMenu
    {
        get
        {
            return ClientDetailsMenu;
        }
        set
        {
            ClientDetailsMenu = value;
        }
    }

    public GameObject GetLastSelectedObject
    {
        get
        {
            return LastSelectedObject;
        }
        set
        {
            LastSelectedObject = value;
        }
    }

    public Button GetClientButton
    {
        get
        {
            return CurrentClientsButton;
        }
        set
        {
            CurrentClientsButton = value;
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

    public EventSystem GetEventSystem
    {
        get
        {
            return eventSystem;
        }
        set
        {
            eventSystem = value;
        }
    }

    public int GetClientIndex
    {
        get
        {
            return clientIndex;
        }
        set
        {
            clientIndex = value;
        }
    }
    #endregion
}
