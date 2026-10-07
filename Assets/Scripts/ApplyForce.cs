using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 force = new Vector3(0f, 0f, 5f);

    void FixedUpdate()
    {
        rb.AddForce(force);
    }
}
