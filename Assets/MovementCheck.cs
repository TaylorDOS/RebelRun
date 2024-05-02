using UnityEngine;

public class MovementCheck : MonoBehaviour
{
    private Vector3 previousPosition;
    private Animator animator;

    void Start()
    {
        previousPosition = transform.position;
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", false);
    }

    void Update()
    {
        bool isMoving = transform.position != previousPosition;
        previousPosition = transform.position;
        animator.SetBool("isMoving", isMoving);
    }
}