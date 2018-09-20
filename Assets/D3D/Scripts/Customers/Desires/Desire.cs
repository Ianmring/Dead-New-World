using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D3D
{

    public abstract class Desire : ScriptableObject
    {

        public float scoreModifier;     //calculates into final 'pay back'
        public bool isNeed;             //if false, is want

        public abstract bool CheckConditionMet(Building building);

    }

}
