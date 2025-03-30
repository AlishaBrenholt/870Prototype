using UnityEngine;

public class CarTracker : MonoBehaviour
{
    // The script transforms the camera this is attatched to to follow the targeted car
    [Header("Objects Settings")]
    public Transform Target; //Target (the car)
    private Camera camera; 

    void Awake()
    {
        camera = GetComponent<Camera>();
    }
    void Update()
    {
        //Setting Camera Position To Target's Position
        transform.position = Target.position;
        
        // add 4 to the x position relative to the front of the car
        transform.position += Target.forward *-5;
        
        // get the car's rotation
        Vector3 lowpolyCarRotation = Target.rotation.eulerAngles;
        
        // Set camera rotation to the out the back of the car
        transform.rotation = Quaternion.Euler(lowpolyCarRotation.x, lowpolyCarRotation.y, lowpolyCarRotation.z);
        transform.rotation = Quaternion.Euler(0, lowpolyCarRotation.y+180, 0);
        
        //Setting Camera Size to 1
        camera.orthographicSize = 1;
    }
}