using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class WrenchTask : MonoBehaviour, Task
{
    public string name => "Wrench Work";
    public UnityEvent OnTaskCompleted { get; set; }
    Vector3 initialPosition;
    
    Quaternion initialRotation;
    
    void Awake()
    {
        //save the initial position
        initialPosition = transform.position;
        //save the initial rotation
        initialRotation = transform.rotation;

        OnTaskCompleted = new UnityEvent();
    }

    public void StartTask()
    {
        Debug.Log("TASK " + name + " Started");
        GetComponent<XRGrabInteractable>().enabled = true;
    }

    public void EndTask()
    {
        Debug.Log("TASK " + name + " COMPLETED");
        OnTaskCompleted?.Invoke();

        GetComponent<XRGrabInteractable>().enabled = false;
        Initialize(gameObject);
    }



    public void Initialize(GameObject prefab)
    {

        transform.rotation = initialRotation;
        transform.position = initialPosition;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
