using UnityEngine;
using UnityEngine.Events;

public class LookAt : MonoBehaviour, Task
{
    public Collider targetLayer;
    public UnityEvent OnTaskCompleted { get; private set; }

    public GameObject PointingArrow;
    public string name => "Look At the Place Shown by the arrow";

    private Animation pointingArrowAnimation;

    private void Awake()
    {
        OnTaskCompleted = new UnityEvent();
        if (PointingArrow != null)
        {
            pointingArrowAnimation = PointingArrow.GetComponent<Animation>();
        }
    }

    public void StartTask()
    {
        Debug.Log("Task1");
        GetComponent<Collider>().enabled = true;

        if (pointingArrowAnimation != null)
        {
            pointingArrowAnimation.Play(); // Plays the default animation
        }
    }

    public void EndTask()
    {
        OnTaskCompleted?.Invoke();
        GetComponent<Collider>().enabled = false;
        Destroy(PointingArrow);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Task " + name + " COMPLETED");
        EndTask();
    }
}
