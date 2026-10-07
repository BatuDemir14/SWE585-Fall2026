using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10f;

    float moveX;
    float moveZ;

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveX, 0f, moveZ) * force);
    }
}
