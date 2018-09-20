using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI
{
    public class SequenceNode : CompositeNode
    {

        public SequenceNode()
        {
            ChildNodes = new List<TreeNode>();
        }

        public override NodeStatus Tick(BehaviorAgent agent)
        {
            if (thisDecorator != null)
                if (TickDecorator(agent) == NodeStatus.SUCCESS) return thisNodeStatus = CheckChildNodeStatus(agent);
                else return thisNodeStatus = NodeStatus.FAILURE;
            else return thisNodeStatus = CheckChildNodeStatus(agent);
        }

        NodeStatus CheckChildNodeStatus(BehaviorAgent agent)
        {
            if (ChildNodes.Count > 0)
            {
                foreach (TreeNode n in ChildNodes)
                {
                    NodeStatus childNodeStatus = n.Tick(agent);

                    if (childNodeStatus == NodeStatus.FAILURE)
                    {
                        return NodeStatus.FAILURE;
                    }
                    else return childNodeStatus;
                }
            }

            return NodeStatus.FAILURE;
        }
    }
}

