using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;

public class TaskManager : MonoBehaviour
{
    public List<GameObject> taskObjects; 
    private int currentTaskIndex = -1;
    public ParticleSystem particleSystem;
    public TMP_Text taskInfoText;
    
    private void Start()
    {
        StartNextTask();
    }

    public void StartNextTask()
    {

        
        if (currentTaskIndex >= 0 && currentTaskIndex < taskObjects.Count)
        {
            var currentTask = taskObjects[currentTaskIndex].GetComponent<Task>();

            if (currentTask != null)
            {
                currentTask.OnTaskCompleted.RemoveListener(OnTaskCompleted);
                currentTask.EndTask();
            }
        }

        currentTaskIndex++;
        if (currentTaskIndex < taskObjects.Count)
        {
            var nextTask = taskObjects[currentTaskIndex].GetComponent<Task>();
            if (nextTask != null)
            {
                nextTask.OnTaskCompleted.AddListener(OnTaskCompleted);
                nextTask.StartTask();
                UpdateTaskInfo(nextTask.name);
            }
        }
        else
        {
            UpdateTaskInfo("All Done");
            if (particleSystem != null)
            {
                particleSystem.Play();
            }



            Debug.Log("All tasks completed.");
        }
    }

    public void OnTaskCompleted()
    {
        Debug.Log("Started "+currentTaskIndex);
        StartNextTask();
    }

    private void UpdateTaskInfo(string taskName)
    {
        if (taskInfoText != null)
        {
            taskInfoText.text = $"Task {currentTaskIndex + 1}: {taskName}";
        }
    }
}
