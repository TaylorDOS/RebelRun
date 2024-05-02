using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeacon : MonoBehaviour
{
    public GameObject beacon;
    private MeshRenderer beaconRenderer; 
    private bool isLightOn = false;
    private int beaconCount = 0;
    private float lightDuration = 10f;
    private float lastBeaconCollectedTime = 0f;

    void Start()
    {
        beaconRenderer = beacon.GetComponent<MeshRenderer>();
        // Initially turn off the spot light
        beaconRenderer.enabled = false;
    }

    void Update()
    {
        // If the light is on, count down the timer
        if (isLightOn)
        {
            lightDuration -= Time.deltaTime;

            // If timer reaches 0, turn off the light
            if (lightDuration <= 0)
            {
                beaconRenderer.enabled = false;
                isLightOn = false;
                lightDuration = 10f; // Reset the duration for the next time

                // Log when the light beacon is turned off
                Debug.Log("beacon turned off");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision object has the "Beacon" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with Beacon cube detected!");

            // Increment beacon count
            beaconCount++;

            // If it's the first beacon, turn on the light
            if (beaconCount == 1)
            {
                beaconRenderer.enabled = true;
                isLightOn = true;
                lastBeaconCollectedTime = Time.time;
            }
            else
            {
                // Check if the beacon was collected within the last 10 seconds
                if (Time.time - lastBeaconCollectedTime <= 10f)
                {
                    // Reset the timer
                    lightDuration = 10f;
                    lastBeaconCollectedTime = Time.time;
                }
                else
                {
                    // If more than 10 seconds have passed since the last beacon, start the timer from now
                    lightDuration = 10f;
                    lastBeaconCollectedTime = Time.time;
                    isLightOn = true;
                    beaconRenderer.enabled = true;
                }
            }

            Destroy(collision.gameObject);
        }
    }
}