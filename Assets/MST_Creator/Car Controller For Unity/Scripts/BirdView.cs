using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BirdView : MonoBehaviour
{
    [Header("Objects Settings")]
    public Transform Target; //Target (the car)
    public int Height; //How high the camera is

    [Header("Button Controller Settings")] 
    public Button button;

    private Image buttonImage;
    public TextMeshProUGUI buttonText;

    public Color enabledColor = Color.green;
    public Color disabledColor = Color.red;
    
    void Start()
    {
        // Get the position of the target
        Vector3 targetPosition = Target.position;
        // Set the camera position to the target position
        transform.position = targetPosition;
        // Add vertical offset
        transform.position += new Vector3(0, Height, 0);
        
        // Set button params
        buttonImage = button.GetComponent<Image>();
        buttonText.text = "BirdView is functional";
        buttonImage.color = enabledColor;
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
    
    // Disable/Enable on button press
    public void SetCameraState()
    {
        Camera cam = GetComponent<Camera>();
        
        if (cam.tag == "Malfunction")
        {
            buttonImage.color = enabledColor;
            cam.tag = "Untagged";
            buttonText.text = "BirdView is functional";
        }
        else
        {
            buttonText.text = "BirdView is malfunctioning";
            cam.tag = "Malfunction";
            buttonImage.color = disabledColor;
        }
    }
}
