using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // This is attatched to the obstacle objects
    [Header("ColorSettings")] 
    // Moved to HighlightController
    // public Color colorSixFeet = Color.yellow;
    //public Color colorThreeFeet = Color.red;
    public bool isHighlighted;
    

    public void SetHighlighted(bool boolean)
    {
        isHighlighted = boolean;
    }
}
