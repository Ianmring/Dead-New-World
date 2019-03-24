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

    [SerializeField]
    private List<Client> CurrentClients;

    [SerializeField]
    private List<Client> ClientsToAdd;

    //Exposed for testing purposes.
    //Set to -1;
    [SerializeField]
    private int ClientIndex;

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
    }

    public void UpdateClients()
    {
        var TextObject = Instantiate(CurrentClientsText);

        TextObject.transform.SetParent(TextParentTransform, false);

        CurrentClientsText.text = CurrentClients[ClientIndex].ClientDetails();
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

    public int GetClientIndex
    {
        get
        {
            return ClientIndex;
        }
        set
        {
            ClientIndex = value;
        }
    }
}
