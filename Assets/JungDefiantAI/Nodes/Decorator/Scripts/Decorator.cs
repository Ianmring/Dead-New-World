using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI
{
    public abstract class Decorator : ScriptableObject
    {
        NodeStatus thisNodeStatus = NodeStatus.SUCCESS;
        TreeNode thisAttachedNode;

        public Conditions.Condition conditionToCheck;
        public NodeStatus Tick(BehaviorAgent agent) { return CheckCondition(); }
        public NodeStatus CheckCondition()  //checks condition; if true, tick childnode and returns tick as status; if false, return failure
        {
            if (conditionToCheck.checkCondition.Invoke()) thisNodeStatus = NodeStatus.FAILURE;
            else thisNodeStatus = NodeStatus.SUCCESS;

            return thisNodeStatus;
        }   
        
    }
}

