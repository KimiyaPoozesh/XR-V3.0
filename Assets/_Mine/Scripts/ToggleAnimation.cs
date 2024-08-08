using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isPlaying;

    public GameObject initObject;
    public AudioSource audio;

    void Awake()
    {
    
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }
    public void PlayAnimation()
    {
        
        if (animator != null)
        {
            isPlaying = true;
            StartCoroutine(WaitAndEndTask(2.7f)); 
            animator.SetBool("isPlaying", isPlaying);
            isPlaying = false;
            audio.Play();
        }
        
    }

    private IEnumerator WaitAndEndTask(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //call EndTask of game objec
        initObject.GetComponent<Task>().EndTask();
    }
}
