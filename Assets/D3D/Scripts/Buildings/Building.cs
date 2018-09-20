using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D3D
{

    public enum BuildingTag { Clown, Monkey, Satanic, Basic }
    public enum BuildingState { Building, Intact, Shabby, Cruddy, Ruined }

    public abstract class PlaceableAsset : MonoBehaviour
    {
        
        [Header("PlaceableAsset Diagnostics")]
        [Tooltip("Diagnostics: Check certain values in-game. Don't modify!")]
        public BuildingState currState;
        public float threshold_shabby;
        public float threshold_cruddy;
        public float currBuildProgress;     //once this equals 100, the state is changed from Building to intact
        public float currStructuralIntegrity;   //once this equals 60%, the state is changed to shabby
                                                //once this equals 30%, the state is changed to cruddy
                                                //once this equals 0, the state is changed to ruined
        [Header("PlaceableAsset Properties")]
        [Tooltip("Properties: Properties for specific assets. Modify away!")]
        public BuildingTag[] bldgTagList;   //some objects check tags, mostly for Desires
        public float maxStructuralIntegrity;
        public float degradationRate;   //this is an hourly rate; set to 0 if it never degrades
        public float buildCost;         //cost of materials to build
        public float maintenanceCost;   //cost of materials to repair per structIntegrity lost
        public bool canBeRepaired;      //if it can be repaired or degrades
    }

    public class Building : PlaceableAsset
    {
        [Header("Building-Specific Properties")]
        public float baseRenownValue;           //how cool is it normally
        public float renownDropRate;     //how quickly renown drops when it is in a lesser state
        public Vector2 tileSize;
        public MenuOptions menuOptions;  //contains a MenuOptions object
        public List<AttachNode> attNodeList;

        [Header("Building-Specific Diagnostics")]
        [Tooltip("Diagnostics: Check the renown value in-game. Don't modify!")]
        public float currRenownValue;   //how cool is it now?

        [HideInInspector]
        public Behaviour halo;

        public Building()
        {
            currBuildProgress = 0;
            currStructuralIntegrity = 0;
            maxStructuralIntegrity = 100;
            threshold_cruddy = maxStructuralIntegrity * 0.3f;
            threshold_shabby = maxStructuralIntegrity * 0.6f;
            degradationRate = 0.12f;
            currState = BuildingState.Building;
        }

        public Building(float newStructuralIntegrity, float newDegradationRate)
        {
            currBuildProgress = 0;
            currStructuralIntegrity = 0;
            maxStructuralIntegrity = newStructuralIntegrity;
            threshold_cruddy = maxStructuralIntegrity * 0.3f;
            threshold_shabby = maxStructuralIntegrity * 0.6f;
            degradationRate = newDegradationRate;
            currState = BuildingState.Building;
        }

        public void Awake()
        {
            halo = (Behaviour)GetComponent("Halo");
            halo.enabled = false;
        }

        void Update ()
        {
            if (currStructuralIntegrity > 0) FallApart();
        }

        public void ProgressBuild()
        {
            currBuildProgress++;
            if(currBuildProgress >= 100)
            {
                currBuildProgress = 100;
                currStructuralIntegrity = maxStructuralIntegrity;
                currState = BuildingState.Intact;
            }
        }

        void FallApart()
        {
            currStructuralIntegrity -= degradationRate;
            CheckIntegrity();
            
        }

        public void HandleDamage(float damage)    //You can also use this function for healing by changing damage to a negative
        {
            currStructuralIntegrity -= damage;
            CheckIntegrity();
        }

        void CheckIntegrity()
        {
            if (currStructuralIntegrity <= 0)
            {
                currStructuralIntegrity = 0;
                currRenownValue = baseRenownValue - (renownDropRate * 4);
                currState = BuildingState.Ruined;
            }
            else if (currStructuralIntegrity <= threshold_cruddy)
            {
                currRenownValue = baseRenownValue - (renownDropRate * 2);
                currState = BuildingState.Cruddy;
            }
            else if (currStructuralIntegrity <= threshold_shabby)
            {
                currRenownValue = baseRenownValue - renownDropRate;
                currState = BuildingState.Shabby;
            }
            else if (currStructuralIntegrity > threshold_shabby)
            {
                currRenownValue = baseRenownValue;
                currState = BuildingState.Intact;
            }
        }
    }

}


