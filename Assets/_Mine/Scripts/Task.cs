using UnityEngine.Events;
public interface Task
{
    string name { get; }
    void StartTask();
    void EndTask();
    UnityEvent OnTaskCompleted { get; }



}
