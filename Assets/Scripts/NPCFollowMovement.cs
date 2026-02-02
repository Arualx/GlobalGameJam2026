using System.Threading;
using UnityEngine;

public class NPCFollowMovement : MonoBehaviour
{
    private float timer = 0f;

    private PlayerMovement playerHealth;
    private Transform playerTransform;
    private ReflectorMovement reflector;

    private float speed = 3f;
    private float stoppingDistance = 2f;
    private float startingDistance = 15f;

    private Vector3 direction;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerTransform = GameObject.Find("Player").transform;
        //reflector = GameObject.Find("Reflector").GetComponent<ReflectorMovement>();

    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);


        if (distance < stoppingDistance)
        {
            direction = Vector3.zero;
            if (timer <= 0f)
            {
                playerHealth.TakeDamage();
                timer = 3f;
            }
            timer -= Time.deltaTime;
        }
        else if (distance <= startingDistance)
        {
            direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(playerTransform);
        }
        else
        {
            direction = Vector3.zero;
            reflector.DecreaseAlertLevel();
        }
    }
}
