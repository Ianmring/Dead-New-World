using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungDefiantAI.Conditions
{
    [System.Serializable]
    public class Variable
    {
        public string _name;
        public Type _type;
        //public T value;

        public Variable(string name, Type type)
        {
            _name = name;
            _type = type;
        }
    }

    public class Condition
    {
        public Variable[] variables;
        public delegate bool CheckCondition();
        public CheckCondition checkCondition;

        public Variable GetVariable(string name)
        {
            for (int v = 0; v < variables.Length; v++)
            {
                if (variables[v]._name == name) return variables[v];
            }

            Debug.Log("variable not found!");
            return null;
        }
    }

    public class ConditionsList
    {
        static readonly object padlock = new object();
        static ConditionsList _conditionsList;
        public static ConditionsList conditionsList
        {
            get
            {
                lock (padlock)
                {
                    if (_conditionsList == null) _conditionsList = new ConditionsList();
                    return _conditionsList;
                }
            }
        }

        public Condition BoolCheck, IntCheck, CheckDistance;

        ConditionsList()
        {
            BoolCheck = new Condition()
            {
                variables = new Variable[] { new Variable("booleanToCheck", typeof(bool)), new Variable("booleanToCompare", typeof(bool)) },
                checkCondition = delegate ()
                {
                    return BoolCheck.GetVariable("booleanToCheck") == BoolCheck.GetVariable("booleanToCompare");
                }
            };
        }
        

        

        
    }
}