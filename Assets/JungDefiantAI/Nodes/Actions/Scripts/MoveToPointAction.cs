using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Pathfinding;

namespace JungDefiantAI
{
    [CreateAssetMenu(fileName = "MoveToPoint Action", menuName = "Assets/JungDefiantAI/Actions/MoveToPoint Action")]
    public class MoveToPointAction : Action
    {
        
        public override void InitializeAction()
        {

        }

        public override NodeStatus PerformAction(BehaviorAgent agent)
        {
            return MoveToTarget(agent);
        }

        NodeStatus MoveToTarget(BehaviorAgent agent)
        {
            if(agent.GetComponent<AIPath>() != null)
            {
                if (agent.GetComponent<AIPath>().canMove != true) agent.GetComponent<AIPath>().canMove = true;
                if (agent.GetComponent<AIPath>().reachedEndOfPath)
                {
                    agent.GetComponent<AIPath>().canMove = false;
                    Debug.Log("Node Success");
                    return NodeStatus.SUCCESS;
                    
                }

                Debug.Log("Node Running");
                return NodeStatus.RUNNING;
                

            }
            return NodeStatus.FAILURE;
        }
    }
}

