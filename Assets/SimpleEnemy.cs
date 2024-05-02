using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    private bool isFollowing = false;
    public float delay = 30;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        // Wait for 10 seconds before enabling following
        yield return new WaitForSeconds(delay);
        isFollowing = true;
        Debug.Log("Enemy started following target");
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            agent.destination = player.position;
        }
    }
}
