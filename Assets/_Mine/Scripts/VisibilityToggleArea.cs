using System;
using UnityEngine;

public class VisibilityToggleArea : MonoBehaviour
{
    public GameObject objectToHide;
    public GameObject objectToShow;
    private string objTag = string.Empty;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wrench") || other.CompareTag("Gear"))
        {
            objTag = other.tag;
            ToggleVisibility(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wrench") || other.CompareTag("Gear"))
        {
            objTag = other.tag;
            ToggleVisibility(false);
        }
       
    }

    public void ToggleVisibility(bool entering)
    {
        Debug.Log(objTag);
        if (objectToHide != null && objectToHide.CompareTag(objTag))
        {
            objectToHide.SetActive(!entering);
        }

        if (objectToShow != null  && objectToHide.CompareTag(objTag))
        {
            objectToShow.SetActive(entering);
        }
    }

    public void Selected(){
        Debug.Log("Selected");
    }
}
