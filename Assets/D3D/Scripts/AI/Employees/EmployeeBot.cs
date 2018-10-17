using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPBehave;
using Pathfinding;

public abstract class EmployeeBot : MonoBehaviour {

    public float Wages;
    protected float CurrentEnergy;
    public float MaximumEnergy;
    protected float CurrentHappiness;
    public float MaximumHappiness;
    protected float CurrentStamina;
    public float MaximumStamina;
    protected float CurrentExperience;
    public float MaximumExperience;
    public float WorkRate;
    public float MovementSpeed;
    public int Level;
    public Transform FollowNode;
    protected AIPath PathAgent;
    protected AIDestinationSetter DestSetter;
    protected Blackboard Blackboard;
    protected Root BehaviorTree;

    public void StaminaChange(float staminaChange)
    {
        CurrentStamina += staminaChange;

        if (CurrentStamina > MaximumStamina) CurrentStamina = MaximumStamina;
        else if (CurrentStamina < 0) CurrentStamina = 0;
    }

    public void HappinessChange(float happinessChange)
    {
        CurrentHappiness += happinessChange;

        if (CurrentHappiness > MaximumHappiness) CurrentHappiness = MaximumHappiness;
        else if (CurrentHappiness < 0) CurrentHappiness = 0;
    }

    public void EnergyChange(float energyChange)
    {
        CurrentEnergy += energyChange;

        if (CurrentEnergy > MaximumEnergy) CurrentEnergy = MaximumEnergy;
        else if (CurrentEnergy < 0) CurrentHappiness = 0;
    }

    public void ExperienceChange(float experienceChange)
    {
        CurrentExperience += experienceChange;

        if (CurrentExperience > MaximumExperience) CurrentExperience = MaximumExperience;
        else if (CurrentExperience < 0) CurrentExperience = 0;
    }

    //Determines when specific types of events are triggered; passes specific EventArgs to OnBehaviorEvent method of BehaviorTreeRef

}