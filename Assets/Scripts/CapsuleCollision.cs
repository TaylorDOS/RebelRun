using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class CapsuleCollision : MonoBehaviour
{
    public float initialMoveSpeed = 1f; // Initial move speed
    public float boostMoveSpeed = 2f; // Move speed during boost
    public float boostDuration = 10f; // Duration of the boost
    public float changeDelay = 10f; // Delay before changing speed back to initial

    private DynamicMoveProvider dynamicMoveProvider;
    private Coroutine boostCoroutine;

    private void Start()
    {
        // Find the player capsule with the tag "yoda"
        GameObject player = GameObject.FindGameObjectWithTag("Move");
        if (player != null)
        {
            // Get the DynamicMoveProvider component attached to the player capsule
            dynamicMoveProvider = player.GetComponent<DynamicMoveProvider>();
            if (dynamicMoveProvider != null)
            {
                // Set the initial move speed
                dynamicMoveProvider.moveSpeed = initialMoveSpeed;
                Debug.Log("Initial move speed set to: " + initialMoveSpeed);
            }
            else
            {
                Debug.LogError("DynamicMoveProvider component not found on the player capsule.");
            }
        }
        else
        {
            Debug.LogError("Player capsule with tag 'yoda' not found.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boost"))
        {
            Debug.Log("Collision with Boost cube detected!");

            // Increase speed to boost speed
            dynamicMoveProvider.moveSpeed = boostMoveSpeed;
            Debug.Log("Speed changed to: " + boostMoveSpeed);

            Destroy(collision.gameObject);

            // Start coroutine to revert back to initial speed after boost duration
            if (boostCoroutine != null)
            {
                StopCoroutine(boostCoroutine);
            }
            boostCoroutine = StartCoroutine(RevertSpeedAfterDelay(boostDuration));
        }

    }

    private IEnumerator RevertSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Revert move speed back to initial value
        dynamicMoveProvider.moveSpeed = initialMoveSpeed;
        Debug.Log("Speed reverted to: " + initialMoveSpeed);
    }
}
