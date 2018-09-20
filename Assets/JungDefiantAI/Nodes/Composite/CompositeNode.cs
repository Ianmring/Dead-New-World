using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI
{
    public abstract class CompositeNode : TreeNode
    {
        public override bool AddChildNode(TreeNode newChild)
        {
            

            if (ChildNodes == null) ChildNodes = new List<TreeNode>();

            if(newChild.depth == -1 || newChild.depth > depth)
            {
                if(newChild.id == id) 
                {
                    Debug.LogError("Cannot attach if ID's are the same!");
                    return false;
                }

                foreach(TreeNode n in ChildNodes)
                {
                    if(newChild.id == n.id)
                    {
                        Debug.LogError("This is already a child node!");
                        return false;
                    }
                }

                newChild.depth = depth + 1;
                ChildNodes.Add(newChild);
                return true;
            }

            Debug.LogError("Depth of child is too high!");
            return false;

        }

    }
}
