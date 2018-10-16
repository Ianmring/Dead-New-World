using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using D3D;
using NPBehave;
using Pathfinding;

public class GroundskeeperAI : EmployeeBot {

	// Use this for initialization
	void Start () {
        //NewGroundskeeper();
        PathAgent = GetComponent<AIPath>();
        DestSetter = GetComponent<AIDestinationSetter>();
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

            new Service(0.8f, UpdateBlackboard,

                new Sequence(

                    new BlackboardCondition("quitJob", Operator.IS_EQUAL, true, Stops.SELF,
                        new Action(() =>
                        {
                            QuitJob();
                            Debug.Log("Quit Job");
                        })
                        { Label = "Quit Job" }
                    ),

                    new BlackboardCondition("askRaise", Operator.IS_EQUAL, true, Stops.SELF,
                        new Action(() =>
                        {
                            AskForRaise();
                            Debug.Log("Ask For Raise");
                        })
                        { Label = "Ask For Raise" }
                    ),

                    /*new Selector(
                        new BlackboardCondition("currentSchedule", Operator.IS_EQUAL, "GoHome", Stops.SELF,
                            new Action(() =>
                            {
                                GoHome();
                            })
                            { Label = "Go Home" }
                        ),

                        new BlackboardCondition("currentSchedule", Operator.IS_EQUAL, "GoToWork", Stops.SELF,
                            new Action(() =>
                            {
                                GoToWork();
                            })
                            { Label = "Go To Work" }
                        )
                    ),*/

                    new Selector(
                        new BlackboardCondition("currentBuilding", Operator.IS_NOT_EQUAL, null, Stops.SELF,
                            new Action((bool _shouldCancel) =>
                            {
                                if (!_shouldCancel)
                                {
                                    RepairBuilding();
                                    return Action.Result.PROGRESS;
                                }
                                else
                                {
                                    return Action.Result.FAILED;
                                }
                            })
                            { Label = "Repair Building" }
                        ),

                        new BlackboardCondition("currentBuilding", Operator.IS_EQUAL, null, Stops.SELF,
                            new Action((bool _shouldCancel) =>
                            {
                                if (!_shouldCancel)
                                {
                                    TakeBreak();
                                    return Action.Result.PROGRESS;
                                }
                                else
                                {
                                    return Action.Result.FAILED;
                                }
                            })
                            { Label = "Take A Break" }
                        )
                    )
                )
            )
        );
    }


    //Update variables
    private void UpdateBlackboard()
    {
        Building currentBuilding = FindBuildingToRepair();
        if (currentBuilding != null)
        {
            CurrentTarget = currentBuilding.transform;
            Debug.Log(currentBuilding.name);
        }
        BehaviorTree.Blackboard["currentBuilding"] = currentBuilding;
        //BehaviorTree.Blackboard["currentSchedule"] = CheckSchedule();
        BehaviorTree.Blackboard["quitJob"] = CheckQuitJob();
        BehaviorTree.Blackboard["askRaise"] = CheckAskRaise();
    }

    private Building FindBuildingToRepair()
    {
        return CheckProximity(transform.position, 5f, 0, "Building");
    }

    private bool CheckQuitJob()
    {
        bool quitJob = false;

        return quitJob;
    }

    private bool CheckAskRaise()
    {
        bool askRaise = false;

        return askRaise;
    }

    /*private string CheckSchedule()
    {
        return "AtWork";
    }*/


    //Actions
    private void QuitJob()
    {
        Debug.Log("Quitting a job");
    }

    private void AskForRaise()
    {
        Debug.Log("Asking for a raise");
    }

    private void GoHome()
    {
        Debug.Log("Going home");
    }

    private void GoToWork()
    {
        Debug.Log("Going to work");
    }

    private void TakeBreak()
    {
        //find random direction and move
        Debug.Log("Taking a break");
        PathAgent.canMove = true;
        if (DestSetter.target != CurrentTarget) DestSetter.target = CurrentTarget;
        if (PathAgent.reachedEndOfPath)
        {
            RandomPath path = RandomPath.Construct(transform.position, 100);
            path.spread = 10;
            GetComponent<Seeker>().StartPath(path);
        }
    }

    private void RepairBuilding()
    {
        if(Vector3.Distance(transform.position, CurrentTarget.position) <= 2.5f)
        {
            PathAgent.canMove = false;
            Debug.Log("Repairing building");
        }
        else
        {
            PathAgent.canMove = true;
            if(DestSetter.target != CurrentTarget) DestSetter.target = CurrentTarget;
        }
    }


    //Utility Methods
    private Building CheckProximity(Vector3 origin, float radius, int layerMask, string tagMatch)
    {
        if (origin != Vector3.zero && radius != 0 && tagMatch != null)
        {
            Collider[] targets = Physics.OverlapSphere(origin, radius);

            foreach (Collider c in targets)
            {
                Debug.Log("Collision found!");
                if (c.gameObject.tag == tagMatch)
                {
                    Debug.Log("Tag match found!");
                    return c.GetComponent<Building>(); //as Building;
                }
            }
        }

        return null;
    }
}
