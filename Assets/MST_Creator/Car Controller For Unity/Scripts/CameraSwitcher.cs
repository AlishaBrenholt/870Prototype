using UnityEngine;
using System.Collections.Generic;

public class CamSwitcher : MonoBehaviour
{
    public List <Camera> cameras = new List<Camera>(); // Array of cameras to switch between
    // The gear text object
    [Header("Needle")]
    public GameObject needle;

    public Speedometer_Controller speedometer;
    
    void Start()
    {
        cameras.AddRange(FindObjectsOfType<Camera>());
        cameras.Remove(Camera.main);
        
        // Get the script from the needle
        speedometer = needle.GetComponent<Speedometer_Controller>();
    }

    void Update()
    {
        if (speedometer.is_reversing)
        {
            // turn on all cameras in list
            foreach (Camera cam in cameras)
            {
                cam.enabled = true;
            }
        } 
        
        else
        {
            foreach (Camera cam in cameras)
            {
                // turn off all cameras in list
                cam.enabled = false;
            }
        }
    }

}
