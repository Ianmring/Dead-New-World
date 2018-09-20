using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JungDefiantAI;

public class EmployeeBot : MonoBehaviour {

    public float Wages;
    protected float CurrentEnergy;
    public float MaximumEnergy;
    protected float CurrentHappiness;
    public float MaximumHappiness;
    public float WorkRate;
    public float MovementSpeed;
    public int Level;
    EmployeeState CurrentState;

    public EmployeeBot()
    {
        Wages = 8.00f;
        MaximumEnergy = 60f;
        MaximumHappiness = 60f;
        WorkRate = 5.0f;
        MovementSpeed = 5.0f;
        Level = 1;
        CurrentState = EmployeeState.Wander;
    }

    //Determines when specific types of events are triggered; passes specific EventArgs to OnBehaviorEvent method of BehaviorTreeRef

}

public enum EmployeeState { GoHome, GoToWork, Maintain, Wander, Chase, Guard }