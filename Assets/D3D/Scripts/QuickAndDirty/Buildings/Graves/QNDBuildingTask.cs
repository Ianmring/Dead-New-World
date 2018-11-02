using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QNDBuildingTask {

    public delegate void ProgressEvent();

    float taskProgress;
    string taskText;
    Dictionary<float, ProgressEvent> progressEvents; //float is time of execution and value is the 'meat'

    public QNDBuildingTask(Dictionary<float, ProgressEvent> newProgressEvents, float newProgress, string newText)
    {
        taskProgress = newProgress;
        taskText = newText;
        newProgressEvents = progressEvents;
    }
}
