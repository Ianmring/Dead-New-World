using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI
{
    public class RootNode : TreeNode
    {


        public override NodeStatus Tick(BehaviorAgent agent)
        {
            if(ChildNodes != null && ChildNodes.Count > 0)
            {
                return ChildNodes[0].Tick(agent);
            }

            return NodeStatus.FAILURE;
        }

        public override bool AddChildNode(TreeNode newChild)
        {
            if (ChildNodes == null) ChildNodes = new List<TreeNode>();

            if (ChildNodes.Count > 0)
            {
                Debug.Log("Too Many Children!");
                return false;
            }

            if (newChild.id == id)
            {
                Debug.Log("Cannot attach if ID's are the same!");
                return false;
            }

            if (newChild.depth != -1)
            {
                Debug.Log("Cannot be assigned child in the middle of tree!");
                return false;
            }

            newChild.depth = 1;
            ChildNodes.Add(newChild);
            return true;
            
        }

    }

}
