﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Client")]
public class ClientData : ScriptableObject
{
    public string Name, CauseOfDeath, ReligiousFaction;

    public Coffin RequestedCoffin;

    public D3D.Headstone RequestedHeadstone;
}