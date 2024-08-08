using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class WrenchTask : MonoBehaviour, Task
{
    public string name;
    public UnityEvent OnTaskCompleted { get; set; }
    Vector3 initialPosition;
    public MoveBolt mb;
    
    Quaternion initialRotation;
    private bool isOpening=true;
    
    void Awake()
    {
        if(gameObject.CompareTag("Wrench")){
            name="Use Wrench on the gear.";
        }
        else{
            name="Place New Gear On the old place";
        }
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
        if(gameObject.CompareTag("Wrench")){
            if(isOpening){
                mb.MoveUp();
            }
            else
                mb.MoveDown();
            Initialize(gameObject);
        }
            
        else
           gameObject.SetActive(false);
    }



    public void Initialize(GameObject prefab)
    {

        transform.rotation = initialRotation;
        transform.position = initialPosition;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
