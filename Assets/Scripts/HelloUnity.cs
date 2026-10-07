using UnityEngine;

public class HelloUnity : MonoBehaviour
{
    public float rotateSpeed = 45f;

    void Start()
    {
        Debug.Log("Hello from " + gameObject.name);
    }

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}
