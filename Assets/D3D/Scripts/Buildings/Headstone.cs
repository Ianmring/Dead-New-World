using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace D3D
{
    public class Headstone : Mod
    {

        public TextMesh engravedName;

        public void SetEngraving(string newEngraving)
        {
            engravedName.text = newEngraving;
        }
    }
}


