using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ActionOnOld : MonoBehaviour,Task
{
    public string name => "Place The Old Gear On the Table";
    private Rotator rotator;
    public UnityEvent OnTaskCompleted { get; private set; }
    public XRSocketInteractor socketInteractor;

    public GameObject table;
    private void Awake()
    {
        OnTaskCompleted = new UnityEvent(); 
        rotator = GetComponent<Rotator>();
    }
    public void StartTask()
    {
        Debug.Log("TASK "+ name + " Started");
        if(table==null){
            socketInteractor.enabled = true;
        }
        GetComponent<XRGrabInteractable>().enabled = true;
        
    }

    public void EndTask()
    {
        GetComponent<XRGrabInteractable>().enabled = false;
        if (table== null && rotator != null){
            rotator.StartRotation();
        }
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
