using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI
{
    public abstract class TreeNode : ScriptableObject
    {

        protected NodeStatus thisNodeStatus;

        public List<TreeNode> ChildNodes;
        public Decorator thisDecorator;
        public int depth;
        public int id;

        public virtual NodeStatus Tick(BehaviorAgent agent) { return thisNodeStatus; }
        public virtual bool AddChildNode(TreeNode newChild) { return false; }

        public NodeStatus TickDecorator(BehaviorAgent agent)
        {
            if (thisDecorator != null) return thisDecorator.Tick(agent);

            return NodeStatus.FAILURE;
        }

    }

    public enum NodeStatus {  RUNNING, SUCCESS, FAILURE }

    //Think of TreeNodes as delegates for tasks

}
