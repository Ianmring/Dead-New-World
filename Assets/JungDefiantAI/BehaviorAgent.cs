using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace JungDefiantAI
{
    [RequireComponent(typeof(AIPath))]
    public class BehaviorAgent : MonoBehaviour
    {

        public BehaviorTree BehaviorTreeRef;
        public float TickTimer;
        float currentTimer;

        void Awake()
        {
            currentTimer = TickTimer;
            GetComponent<AIPath>().canMove = false;
        }
        
        void Update()
        {
            
            if(currentTimer >= TickTimer)
            switch(TickBehaviorTree(this))
            {
                case NodeStatus.RUNNING: currentTimer = 0; return;
                case NodeStatus.FAILURE: currentTimer = TickTimer; return;
                case NodeStatus.SUCCESS: currentTimer = TickTimer; return;
            }
            currentTimer += Time.deltaTime;

        }

        NodeStatus TickBehaviorTree(BehaviorAgent agent)
        {
            return BehaviorTreeRef.TickBehaviorTree(agent);
        }

    }
}

