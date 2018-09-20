using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI
{
    [CreateAssetMenu(fileName = "Catalog", menuName = "Assets/JungDefiantAI/Catalog")]
    public class Catalog : ScriptableObject
    {
        public string[] catalog;
    }
}

