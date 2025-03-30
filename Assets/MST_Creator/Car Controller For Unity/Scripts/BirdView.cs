using UnityEngine;

public class BirdView : MonoBehaviour
{
    [Header("Objects Settings")]
    public Transform Target; //Target (the car)
    public int Height; //How high the camera is
    
    void Start()
    {
        // Get the position of the target
        Vector3 targetPosition = Target.position;
        // Set the camera position to the target position
        transform.position = targetPosition;
        // Add vertical offset
        transform.position += new Vector3(0, Height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Update rotation compared to target
        transform.rotation = Quaternion.Euler(90, Target.eulerAngles.y, 0);
        // Update the position as well
        transform.position = Target.position;
        transform.position += new Vector3(0, Height, 0);
    }
}
