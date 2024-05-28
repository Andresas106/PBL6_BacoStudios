using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    // Speed at which the object will move
    public float speed = 5.0f;

    // Starting position of the object
    public float startYPosition = 0.0f;

    // Maximum height the object can reach
    public float maxHeight = 100.0f; // Increased from 5.0f

    // Minimum height the object can reach
    public float minHeight = -100.0f; // Decreased from -5.0f

    private void Update()
    {
        // Calculate the new y position based on time and speed
        float newYPosition = startYPosition + Mathf.Sin(Time.time * speed);

        // Clamp the new y position within the maximum and minimum heights
        newYPosition = Mathf.Clamp(newYPosition, minHeight, maxHeight);

        // Set the object's new position
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}

