using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class SpeecChange : MonoBehaviour
{
    public float newMoveSpeed = 10f; // Set your desired move speed here

    private void Start()
    {
        // Get the DynamicMoveProvider component attached to the same GameObject
        DynamicMoveProvider dynamicMoveProvider = GetComponent<DynamicMoveProvider>();

        // Check if the component exists
        if (dynamicMoveProvider != null)
        {
            // Set the new move speed
            dynamicMoveProvider.moveSpeed = newMoveSpeed;
        }
        else
        {
            Debug.LogError("DynamicMoveProvider component not found on the GameObject.");
        }
    }
}
