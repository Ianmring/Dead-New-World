using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D3D
{
    public class ProximityDesire : Desire {

        BuildingTag[] goodTypes;    //enum values for good building tags
        BuildingTag[] badTypes;     //enum values for bad building tags


        public override bool CheckConditionMet(Building building)
        {
            return CheckProximityAndCalculateScore(building);
        }

        bool CheckProximityAndCalculateScore(Building building)
        {
            Collider[] buildingOverlap = Physics.OverlapSphere(building.transform.position, building.GetComponent<Collider>().bounds.size.magnitude * 2f, 8);
            List<Building> buildingList = new List<Building>();

            bool conditionMet = true;

            if (buildingOverlap.Length > 0)
            {
                for (int i = 0; i < buildingOverlap.Length; i++)
                {
                    buildingList.Add(buildingOverlap[i].GetComponent<Building>());
                }

                for (int i = 0; i < buildingList.Count; i++)
                {
                    for(int t = 0; t < buildingList[i].bldgTagList.Length; i++)
                    {
                        for(int gt = 0; gt < goodTypes.Length; gt++)
                        {
                            if (goodTypes[gt] == buildingList[i].bldgTagList[t] && !isNeed) scoreModifier += 1;
                        }

                        for (int bt = 0; bt < badTypes.Length; bt++)
                        {
                            if (badTypes[bt] == buildingList[i].bldgTagList[t])
                            {
                                conditionMet = false;

                                if(isNeed) scoreModifier -= 1;
                            }
                        }
                    }
                }
            }

            return conditionMet;
        }
    }

}
