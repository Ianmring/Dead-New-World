using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI
{
    public abstract class Decorator : ScriptableObject
    {
        NodeStatus thisNodeStatus = NodeStatus.SUCCESS;
        TreeNode thisAttachedNode;

        public virtual NodeStatus CheckCondition() { return thisNodeStatus; }   //checks condition; if true, tick childnode and returns tick as status; if false, return failure
        public virtual NodeStatus Tick(BehaviorAgent agent) { return CheckCondition(); }
    }
}

