using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 90f;  
    public bool isRotating = false;     
    public float duration = 2.0f;      
    private Coroutine rotationCoroutine;
    public GameObject initObject;
public AudioSource audioSource;

    public void StartRotation(float duration)
    {
       
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
        }
        isRotating = true;
        rotationCoroutine = StartCoroutine(RotateForDuration(duration));
        audioSource.Play();
    }

    public void StopRotation(){
        isRotating=false;
    }

    private IEnumerator RotateForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        isRotating = false;
        audioSource.Stop();
        initObject.GetComponent<Task>().EndTask();

    }

    private void Update()
    {
        if(isRotating){
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
