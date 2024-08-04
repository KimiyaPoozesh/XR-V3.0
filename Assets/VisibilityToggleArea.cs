using UnityEngine;

public class VisibilityToggleArea : MonoBehaviour
{
    public GameObject objectToHide;
    public GameObject objectToShow;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wrench"))
        {
            ToggleVisibility(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wrench"))
        {
            ToggleVisibility(false);
        }
        Debug.Log("Wrench exited");
    }

    public void ToggleVisibility(bool entering)
    {
        if (objectToHide != null)
        {
            objectToHide.SetActive(!entering);
        }

        if (objectToShow != null)
        {
            objectToShow.SetActive(entering);
        }
    }

    public void Selected(){
        Debug.Log("Selected");
    }
}
