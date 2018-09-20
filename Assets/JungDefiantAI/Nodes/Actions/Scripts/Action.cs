using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace JungDefiantAI
{
    public abstract class Action : ScriptableObject
    {

        public abstract NodeStatus PerformAction(BehaviorAgent agent);
        public List<SerializedProperty> EditableActionProperties;
        protected bool isInitialized = false;

        public abstract void InitializeAction();

    }
}

