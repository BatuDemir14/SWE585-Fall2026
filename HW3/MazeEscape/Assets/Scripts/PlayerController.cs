using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public float moveSpeed = 5f;
    public float turnSpeed = 160f;

    float moveInput;
    float turnInput;

    void Update()
    {
        // W/S moves forward and back, A/D turns the player
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        animator.SetBool("isRunning", moveInput != 0f);
    }

    void FixedUpdate()
    {
        Quaternion turn = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turn);

        Vector3 velocity = transform.forward * moveInput * moveSpeed;
        velocity.y = rb.linearVelocity.y; // keep gravity
        rb.linearVelocity = velocity;
    }
}
