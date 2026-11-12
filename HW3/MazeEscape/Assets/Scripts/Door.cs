using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    public float openAngle = 100f;
    public float openSpeed = 90f;

    bool isOpen = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key" && isOpen == false)
        {
            isOpen = true;
            Debug.Log("key hit the door");
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        float rotated = 0f;
        while (rotated < openAngle)
        {
            float step = openSpeed * Time.deltaTime;
            transform.Rotate(0f, step, 0f);
            rotated += step;
            yield return null;
        }

        gameManager.WinGame();
    }
}
