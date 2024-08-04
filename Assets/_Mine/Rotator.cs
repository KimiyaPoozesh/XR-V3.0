using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 90f;  // Rotation speed in degrees per second
    public bool isScrewRotation = true;  // If true, mimic screwing rotation; otherwise, different rotation
    public bool isRotating = false;     // Is the object currently rotating?
    public float duration = 2.0f;       // Duration for the rotation
    private Coroutine rotationCoroutine;

    public void StartRotation()
    {
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
        }
        isRotating = true;
        rotationCoroutine = StartCoroutine(RotateForDuration(duration));
    }

    private IEnumerator RotateForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        isRotating = false;
    }

    private void Update()
    {
        if (isRotating)
        {
            Vector3 rotationAxis;

            if (isScrewRotation)
            {
                rotationAxis = Vector3.forward;
            }
            else
            {
                rotationAxis = Vector3.up;
            }

            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }
    }
}
