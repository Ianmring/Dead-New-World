using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI
{
    public class BehaviorTree : ScriptableObject
    {

        public List<TreeNode> TreeNodeList;

        public void Initialize()
        {
            TreeNodeList = new List<TreeNode>();
        }

        public bool AddChildNode(int parentID, int childID)
        {
            return TreeNodeList[parentID].AddChildNode(TreeNodeList[childID]);
        }

        public NodeStatus TickBehaviorTree(BehaviorAgent agent)
        {
            return TreeNodeList[0].Tick(agent);
        }
    }
}

