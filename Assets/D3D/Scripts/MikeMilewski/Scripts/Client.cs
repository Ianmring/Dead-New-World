using UnityEngine;

//This class holds data of each client instance by
//reading from the ClientData scriptable object class
//and setting its values with that of the Client variables.
public class Client : MonoBehaviour
{
    [SerializeField]
    private ClientData clientData;

    [SerializeField]
    private string Name, CauseOfDeath, ReligiousFaction, CurrentStatusOfBurial;

    [SerializeField]
    private float TimeRemainingToBury;

    [SerializeField]
    private Coffin RequestedCoffin = null;

    [SerializeField]
    private D3D.Headstone RequestedHeadstone = null;

    private void Awake()
    {
        Name = clientData.Name;
        CauseOfDeath = clientData.CauseOfDeath;
        ReligiousFaction = clientData.ReligiousFaction;

        RequestedCoffin = clientData.RequestedCoffin;
        RequestedHeadstone = clientData.RequestedHeadstone;
    }

    public string NewRequestedClientDetails()
    {
        Name = clientData.Name;
        RequestedCoffin = clientData.RequestedCoffin;
        RequestedHeadstone = clientData.RequestedHeadstone;

        return Name + "\n" + "Requested Coffin: " + RequestedCoffin + "\n" + "Requested Headstone: " + RequestedHeadstone;
    }

    public string ClientMenuDetails()
    {
        Name = clientData.name;
        CurrentStatusOfBurial = clientData.CurrentStatusOfBurial;
        TimeRemainingToBury = clientData.TimeRemainingToBury;

        return Name + "\n" + "Burial Status: " + CurrentStatusOfBurial + "\n" + "Burial Time: " + TimeRemainingToBury;
    }

    public string AdditionalClientDetails()
    {
        Name = clientData.Name;
        CauseOfDeath = clientData.CauseOfDeath;
        ReligiousFaction = clientData.ReligiousFaction;

        return Name + "\n" + "Cause of death: " + CauseOfDeath + "\n" + "Religion: " + ReligiousFaction;
    }

    public ClientData GetClientData
    {
        get
        {
            return clientData;
        }
        set
        {
            clientData = value;
        }
    }
}
