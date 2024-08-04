using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TaskAnimation : MonoBehaviour, Task
{
    public string name => "Wrench Work";
    private Animator animator;
    public GameObject Bolt;
    private bool isPlaying;
    public UnityEvent OnTaskCompleted { get; set; }
    public XRSocketInteractor socketInteractor;
    public Transform targetPosition; 


    void Awake()
    {
        OnTaskCompleted = new UnityEvent(); 
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    public void StartTask()
    {
        Debug.Log("TASK "+ name + " Started");
        //masmalli
        socketInteractor.enabled = false;
        GetComponentInParent<XRGrabInteractable>().enabled = true;
    }

    public void EndTask()
    {
        Debug.Log("TASK "+ name + " COMPLETED");
        OnTaskCompleted?.Invoke();
        animator.SetBool("isPlaying", isPlaying);
        GetComponentInParent<XRGrabInteractable>().enabled = true;
        Destroy(transform.parent.gameObject);
        
        
        MoveBolt();
    }

    public void ToggleAnimation()
    {
        GetComponentInParent<XRGrabInteractable>().enabled = false;
        if (animator != null)
        {
            isPlaying = true;
            StartCoroutine(WaitAndEndTask(2.7f)); 
            animator.SetBool("isPlaying", isPlaying);
            isPlaying = false;
        }
        
    }

    private IEnumerator WaitAndEndTask(float waitTime)
    {
       
        yield return new WaitForSeconds(waitTime);
        
        EndTask();
    }

    public void MoveBolt()
    {
        Debug.Log("Moving bolt");
        Vector3 position = Bolt.transform.position;  
        position.y +=  0.5f;
        Bolt.transform.position = position; 
    }

    
}
