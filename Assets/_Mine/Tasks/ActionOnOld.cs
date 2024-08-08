using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ActionOnOld : MonoBehaviour,Task
{
    public string name => "Place The Old Gear On the Table";
    private Rotator rotator;
    public UnityEvent OnTaskCompleted { get; private set; }
    public GameObject table;
    
    private void Awake()
    {
        OnTaskCompleted = new UnityEvent(); 
        rotator = GetComponent<Rotator>();
    }
    public void StartTask()
    {
        Debug.Log("TASK "+ name + " Started");

        GetComponent<XRGrabInteractable>().enabled = true;
        
    }

    public void EndTask()
    {
        GetComponent<XRGrabInteractable>().enabled = false;
        OnTaskCompleted?.Invoke();
        
    }
    


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TASK Colided with " + collision.gameObject.name);

        if (collision.gameObject == table)
        {
            Debug.Log("TASK " + name + " COMPLETED");
            EndTask();
        }
    }

    
}
