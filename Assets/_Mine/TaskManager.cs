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
        public TMP_Text BigScreen;

    private List<string> sentences = new List<string>
    {
        "There were a problem in our motor engine.",
        "Your task is to fix it so that we can continue our journey.",
        "Go outside and find the stairs to get up you will then see the instruction to do your task",
        "GO GO GO GO !!!!"
        
    };
    private int sentenceIndex = -1;
    
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
            BigScreen.text="WellDone Ranger You may now die";
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

    public void ShowNextSentence()
    {
        sentenceIndex++;
        if (sentenceIndex < sentences.Count)
        {
            BigScreen.text = sentences[sentenceIndex];
        }
        else
        {
            BigScreen.text="END";
        }
    }
}
