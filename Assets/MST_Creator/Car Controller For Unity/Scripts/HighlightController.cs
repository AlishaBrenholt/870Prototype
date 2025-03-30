using UnityEngine;
using System.Collections.Generic;

public class HighlightController : MonoBehaviour
{
    [Header("Objects Settings")]
    public float warningDistance = 16f;

    public float strongWarningDistance = 8f;
    public Color colorSixFeet = Color.yellow;
    public Color colorThreeFeet = Color.red;
    public float brakeDistance = 4f;
    private List<Sensor> sensors = new List<Sensor>();
    private List<Obstacle> obstacles = new List<Obstacle>();
    private Transform targetTransform;
    private Collider targetCollider;
    private Car_Controller controller;
    public float brakeFraction = -.05f;
    private Rigidbody carRigidBody;

    void Awake()
    {
        targetTransform = GetComponent<Transform>();
        targetCollider = GetComponentInChildren<MeshCollider>();
        controller = GetComponent<Car_Controller>();
        carRigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Get all cameras that have the sensor script
        sensors.AddRange(FindObjectsOfType<Sensor>());
        Debug.Log("Sensors: " + sensors.Count);
        
        // Get all objects that have the obstacle script
        obstacles.AddRange(FindObjectsOfType<Obstacle>());
        Debug.Log("Obstacles: " + obstacles.Count);
    }

    void Update()
    {
        bool inReverse = sensors[0].camera.isActiveAndEnabled;
        if (!inReverse)
        {
            controller.automaticBrake = false;
        }
        foreach (Obstacle obstacle in obstacles)
        {
            // Get collider to determine distance
            Collider col = obstacle.GetComponent<Collider>();
            Vector3 closestPoint = col.ClosestPoint(targetTransform.position);
            Vector3 closestPoint2 = targetCollider.ClosestPoint(obstacle.transform.position);
            float distance = Vector3.Distance(closestPoint, closestPoint2);
            
            // Set color and see if in view
            Renderer render = obstacle.GetComponent<Renderer>();
            
            
            // Alerts only happen within 6 feet
            if ((distance > warningDistance) || !inReverse)
            {
                render.material.color = Color.white;
                obstacle.SetHighlighted(false);
                continue;
            }
            
            // Checks object is in view of any of the cameras
            foreach (Sensor sensor in sensors)
            {
                // https://discussions.unity.com/t/how-can-i-know-if-a-gameobject-is-seen-by-a-particular-camera/248
                if (render.isVisible)
                {
                    obstacle.SetHighlighted(true);
                    render.material.color = GetColor(distance);
                    bool isOverride = Input.GetKey(KeyCode.S);
                    if (distance <= brakeDistance)
                    {
                        controller.automaticBrake = !isOverride;
                        if (!isOverride)
                        {
                            Debug.Log("Braking car now");
                        }
                        controller.BrakeCar();
                    }
                    else
                    {
                        controller.automaticBrake = false;
                    }

                    // We know it is within distance and viewable by this camera, now draw the bounding box around the object

                }
            }
            
        }
    }

    Color GetColor(float dist)
    {
        if (dist < strongWarningDistance)
        {
            return colorThreeFeet;
        }
        if (dist < warningDistance)
        {
            return colorSixFeet;
        }
        return Color.white;
    }
}
