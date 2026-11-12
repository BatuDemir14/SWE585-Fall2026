using System.Collections;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public Animator animator;
    public GameManager gameManager;

    public float speed = 2f;
    public float waitTime = 1.5f;
    public float viewDistance = 3f;
    public float viewAngle = 45f;

    void Start()
    {
        transform.position = pointA.position;
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        Transform target = pointB;

        while (true)
        {
            transform.LookAt(target.position);
            animator.SetBool("isWalking", true);

            while (Vector3.Distance(transform.position, target.position) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                yield return null;
            }

            // wait a little at the end of the path, then go back
            animator.SetBool("isWalking", false);
            yield return new WaitForSeconds(waitTime);

            if (target == pointB)
            {
                target = pointA;
            }
            else
            {
                target = pointB;
            }
        }
    }

    void Update()
    {
        // the guard only sees the player if he is close and in front
        Vector3 toPlayer = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, toPlayer);

        if (toPlayer.magnitude < viewDistance && angle < viewAngle)
        {
            gameManager.LoseGame("A guard saw you!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.LoseGame("You ran into a guard!");
        }
    }
}
