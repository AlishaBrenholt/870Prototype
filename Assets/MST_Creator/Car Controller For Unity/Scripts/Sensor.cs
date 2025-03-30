using UnityEngine;

public class Sensor : MonoBehaviour
{
    // This is attatched to any of the cameras that is a sensor so it highlights objects if in view
    public Camera camera; 

    void Awake()
    {
        camera = GetComponent<Camera>(); // Wow, turns out we don't need to do the manuage assignment
        Debug.Log("Camera: " + camera.name);
    }
    
}
