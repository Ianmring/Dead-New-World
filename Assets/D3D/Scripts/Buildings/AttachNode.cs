using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D3D
{

    public enum NodeTag { Null, Headstone }

    public class AttachNode : MonoBehaviour
    {

        public NodeTag nodeTag;
        public bool isAttached;

    }

}

