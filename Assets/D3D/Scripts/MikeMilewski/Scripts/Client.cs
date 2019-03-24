using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField]
    private ClientData clientData;

    [SerializeField]
    private string Name, CauseOfDeath, ReligiousFaction;

    [SerializeField]
    private Coffin RequestedCoffin;

    [SerializeField]
    private D3D.Headstone RequestedHeadstone;

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

        return Name;
    }
}
