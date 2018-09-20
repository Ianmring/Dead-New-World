using System.Collections.Generic;
using UnityEditor;

namespace JungDefiantAI
{
    public class ActionNode : TreeNode
    {

        public Action thisAction;

        void OnEnable()
        {
            ChildNodes = null;
        }

        public override NodeStatus Tick(BehaviorAgent agent)
        {
            if (thisAction != null)
            {
                if(thisDecorator != null)
                    if(TickDecorator(agent) == NodeStatus.SUCCESS) return thisAction.PerformAction(agent);
                    else return thisNodeStatus = NodeStatus.FAILURE;
                else return thisAction.PerformAction(agent);
            }

            return thisNodeStatus = NodeStatus.FAILURE;

        }

        public override bool AddChildNode(TreeNode newChild)
        {
            return false;
        }
    }
}

