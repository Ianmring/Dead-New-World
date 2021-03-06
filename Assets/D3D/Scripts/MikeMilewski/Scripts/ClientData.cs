﻿using UnityEngine;

[CreateAssetMenu(fileName = "Client")]
public class ClientData : ScriptableObject
{
    public string Name, CauseOfDeath, ReligiousFaction, CurrentStatusOfBurial;

    public float TimeRemainingToBury;

    public Coffin RequestedCoffin = null;

    public D3D.Headstone RequestedHeadstone = null;
}
