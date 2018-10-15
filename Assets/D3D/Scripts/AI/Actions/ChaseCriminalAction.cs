/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[System.Serializable]
public class ChaseCriminalAction : Action
{

    Transform targetPosition;
    float attackRange;

    public ChaseCriminalAction(BehaviorAgent agent, float newRange)
    {
        if (agent.GetComponent<EmployeeBot>() != null)
        {
            Debug.Log("new target set!");
            targetPosition = agent.GetComponent<EmployeeBot>().CurrentTarget;
        }
        attackRange = newRange;
    }

    public override NodeStatus PerformAction(BehaviorAgent agent)
    {
        if (agent.GetComponent<EmployeeBot>() == null
            || agent.GetComponent<EmployeeBot>().CurrentTarget == null)
            return NodeStatus.FAILURE;
        else
        {
            targetPosition = agent.GetComponent<EmployeeBot>().CurrentTarget;
            return ChaseVandal(agent);
        }
    }

    NodeStatus ChaseVandal(BehaviorAgent agent)
    {

        if (agent.GetComponent<AIPath>() != null
            && agent.GetComponent<AIDestinationSetter>() != null)
        {
            Debug.Log("Node Running");
            if (Vector3.Distance(agent.transform.position, targetPosition.position) > attackRange)
            {
                Debug.Log("Moving now");

                if (agent.GetComponent<AIPath>().canMove != true)
                {
                    Debug.Log("Can move!");
                    agent.GetComponent<AIPath>().canMove = true;
                }

                if (agent.GetComponent<AIDestinationSetter>().target != targetPosition)
                {
                    Debug.Log("Set Destination!");
                    agent.GetComponent<AIDestinationSetter>().target = targetPosition;
                }
                return NodeStatus.RUNNING;
            }
            else return CatchVandal(agent);
        }

        Debug.Log("Node failed!");
        return NodeStatus.FAILURE;
    }

    NodeStatus CatchVandal(BehaviorAgent agent)
    {
        //Code for catching criminal
        return NodeStatus.SUCCESS;
    }
}
*/
