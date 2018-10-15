using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPBehave;
using Pathfinding;

public class GroundskeeperAI : EmployeeBot {

	// Use this for initialization
	void Start () {
        NewGroundskeeper();
        BehaviorTree = CreateBehaviorTree();
        Blackboard = BehaviorTree.Blackboard;
        BehaviorTree.Start();
    }

    void NewGroundskeeper(float startWage = 8.00f, float startEnergy = 60f, float startHappi = 60f,
        float startStamina = 10f, float startWorkRate = 5.0f, float startMove = 5.0f, int startLevel = 1)
    {
        Wages = startWage;
        MaximumEnergy = startEnergy;
        MaximumHappiness = startHappi;
        MaximumStamina = startStamina;
        CurrentStamina = MaximumStamina;
        WorkRate = startWorkRate;
        MovementSpeed = startMove;
        Level = startLevel;
    }

    private Root CreateBehaviorTree()
    {
        // we always need a root node
        return new Root(

            new Service(0.125f, UpdateTasking,

                new Selector(

                    new BlackboardCondition("playerDistance", Operator.IS_SMALLER, 7.5f, Stops.IMMEDIATE_RESTART,

                        new Sequence(
                            new Action((bool _shouldCancel) =>
                            {
                                if (!_shouldCancel)
                                {
                                    //MoveTowards(blackboard.Get<Vector3>("playerLocalPos"));
                                    return Action.Result.PROGRESS;
                                }
                                else
                                {
                                    return Action.Result.FAILED;
                                }
                            })
                            { Label = "Follow" }
                        )
                    ),

                    // park until playerDistance does change
                    new Sequence(
                        new WaitUntilStopped()
                    )
                )
            )
        );
    }

    private void UpdateTasking()
    {
        Vector3 playerLocalPos = this.transform.InverseTransformPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        BehaviorTree.Blackboard["playerLocalPos"] = playerLocalPos;
        BehaviorTree.Blackboard["playerDistance"] = playerLocalPos.magnitude;
    }
}
