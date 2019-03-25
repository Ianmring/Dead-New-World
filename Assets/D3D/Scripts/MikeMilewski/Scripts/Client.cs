using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class holds data of each client instance by
//reading from the ClientData scriptable object class
//and setting its values with that of the Client variables.
public class Client : MonoBehaviour
{
    [SerializeField]
    private ClientData clientData;

    [SerializeField]
    private string Name, CauseOfDeath, ReligiousFaction;

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

    public string ClientDetails()
    {
        Name = clientData.Name;
        CauseOfDeath = clientData.CauseOfDeath;
        ReligiousFaction = clientData.ReligiousFaction;

        RequestedCoffin = clientData.RequestedCoffin;
        RequestedHeadstone = clientData.RequestedHeadstone;

        return Name + "\n" + CauseOfDeath + ", " + ReligiousFaction;
    }
}
