using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Transform spikes;
    public GameManager gameManager;
    public float upTime = 2f;
    public float downTime = 3f;
    public float startDelay = 0f;
    public float moveSpeed = 8f;
    public float hiddenY = -2f;

    bool isActive = false;
    bool playerInside = false;

    void Start()
    {
        // spikes start hidden under the floor
        spikes.localPosition = new Vector3(0f, hiddenY, 0f);
        StartCoroutine(TrapRoutine());
    }

    IEnumerator TrapRoutine()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            // trap is disabled
            yield return new WaitForSeconds(downTime);

            // enable the trap
            isActive = true;
            yield return StartCoroutine(MoveSpikes(0f));
            yield return new WaitForSeconds(upTime);

            // disable it again
            yield return StartCoroutine(MoveSpikes(hiddenY));
            isActive = false;
        }
    }

    IEnumerator MoveSpikes(float targetY)
    {
        Vector3 targetPos = new Vector3(0f, targetY, 0f);
        while (spikes.localPosition != targetPos)
        {
            spikes.localPosition = Vector3.MoveTowards(spikes.localPosition, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void Update()
    {
        if (isActive && playerInside)
        {
            gameManager.LoseGame("You were caught by the spikes!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInside = false;
        }
    }
}
