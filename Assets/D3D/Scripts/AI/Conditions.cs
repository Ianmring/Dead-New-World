using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Condition : UnityEngine.Object
{
    public string conditionName;
    public abstract bool CheckCondition();
}

[Serializable]
public class BoolCheck : Condition
{
    bool _booleanToCheck;
    bool _booleanToCompare;

    public BoolCheck(bool booleanToCheck, bool booleanToCompare)
    {
        _booleanToCheck = booleanToCheck;
        _booleanToCompare = booleanToCompare;
        conditionName = "BoolCheck";
    }

    public override bool CheckCondition()
    {
        return _booleanToCheck == _booleanToCompare;
    }
}

[Serializable]
public class CheckProximity : Condition
{
    Vector3 _origin;
    float _radius;
    int _layerMask;
    string _tagMatch;

    public CheckProximity(Vector3 origin, float radius, int layerMask, string tagMatch)
    {
        _origin = origin;
        _radius = radius;
        _layerMask = layerMask;
        _tagMatch = tagMatch;
        conditionName = "ProximityCheck";
    }

    public override bool CheckCondition()
    {
        bool checkProximity = false;

        if (_origin != null && _radius != 0 && _tagMatch != null)
        {
            Collider[] targets = Physics.OverlapSphere(_origin, _radius);

            foreach (Collider c in targets)
            {
                Debug.Log("Collision found!");
                if (c.gameObject.tag == _tagMatch)
                {
                    Debug.Log("Name match found!");
                    checkProximity = true;
                }
            }
        }
        Debug.Log("Check proximity is equal to " + checkProximity);
        return checkProximity;
    }
}

/*
[Serializable]
public class CheckVisionRange : Condition
{
    Transform _origin;
    float _range;
    int _layerMask;
    string _tagMatch;

    public CheckVisionRange(Transform origin, float range, int layerMask, string tagMatch)
    {
        _origin = origin;
        _range = range;
        _layerMask = layerMask;
        _tagMatch = tagMatch;
        conditionName = "CheckRaycast";
    }

    public override bool CheckCondition()
    {
        bool checkRaycast = false;

        if (_origin != null && _range != 0 && _tagMatch != null)
        {
            Ray raycast = new Ray(_origin.position, _origin.forward);
            RaycastHit hit;

            if (Physics.Raycast(raycast, out hit, _range))
            {
                if(hit.transform.gameObject.tag == _tagMatch)
                {
                    if (_origin.GetComponent<Enemy>() != null)
                    {
                        if (hit.transform.GetComponent<AbsoluteUnit>() != null)
                        {
                            if(hit.transform.GetComponent<AbsoluteUnit>().effectReceiver != null)
                            {
                                Debug.Log("Checking stealth tag");

                                EffectTag stealthTag = hit.transform.GetComponent<AbsoluteUnit>().effectReceiver.GetPassiveTag("Stealth");
                                if (stealthTag != null)
                                {
                                    if (stealthTag.level == 2
                                    && Vector3.Distance(_origin.transform.position, hit.transform.position) < (_range / 4))
                                        _origin.GetComponent<Enemy>().currentTarget = hit.transform;
                                    else if (stealthTag.level == 1
                                        && Vector3.Distance(_origin.transform.position, hit.transform.position) < (_range / 2))
                                        _origin.GetComponent<Enemy>().currentTarget = hit.transform;
                                }
                                else
                                {
                                    _origin.GetComponent<Enemy>().currentTarget = hit.transform;
                                    Debug.Log("Target found!");
                                }
                            }
                        }
                    }

                    checkRaycast = true;
                }
            }

            /*Debug.Log("Collision found!");
                if (c.gameObject.name == _tagMatch)
                {
                    Debug.Log("Name match found!");
                    checkRaycast = true;
                }
        }
        Debug.Log("Check proximity is equal to " + checkRaycast);
        return checkRaycast;
    }
}*/
