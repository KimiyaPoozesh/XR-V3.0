using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Events;
using UnityEngine;

public class ScrewTask : MonoBehaviour,Task
{
    
    public string name => "Tighten the screw with a screwdriver";
    private Rotator rotator;
    public bool isWorking=false;
    public bool onNewGear = false;
    public UnityEvent OnTaskCompleted { get; private set; }
    public GameObject NewGear;
    private void Awake()
    {
        OnTaskCompleted = new UnityEvent(); 
        rotator = GetComponent<Rotator>();
    }

    public void StartTask()
    {
        Debug.Log("TASK "+ name + " Started");
        GetComponentInParent<XRGrabInteractable>().enabled = true;
        
    }
    public void EndTask()
    {
        if(isWorking && onNewGear)
        {
            Debug.Log("TASK "+ name + " Completed");
            GetComponentInParent<XRGrabInteractable>().enabled = false;
            OnTaskCompleted?.Invoke();
            Destroy(gameObject);
            }
    }

    public void ToggleWork(){
        isWorking=!isWorking;
    }

    private void OnCollisionEnter(Collision other) {
    Debug.Log("SCREW Touched");
    if (other.gameObject == NewGear) {
       onNewGear = true;
       EndTask();
    }
}

private void OnCollisionExit(Collision other) {
    Debug.Log("SCREW UnTouched");
    if (other.gameObject == NewGear) {
       onNewGear = false;
    }
}


}
