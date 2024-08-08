using UnityEngine;

public class MoveBolt : MonoBehaviour
{
    private float moveAmount = 0.2f;

    // Method to move the object up by 5 units
    public void MoveUp()
    {
        transform.position += new Vector3(0, moveAmount, 0);
        Debug.Log("Moved Up by " + moveAmount + " units");
    }

    // Method to move the object down by 5 units
    public void MoveDown()
    {
        transform.position -= new Vector3(0, moveAmount, 0);
        Debug.Log("Moved Down by " + moveAmount + " units");
    }
}
