using UnityEngine;
using UnityEngine.AI;


using System.Collections;

public class WanderingAI : MonoBehaviour
{

    public float wanderRadius;
    public float minVrijeme = 1;
    public float maxVrijeme = 8;
    private float wanderTimer; //= Random.Range(1, 10);

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public float damping = 5f;//sto je vece to je sporije

    // Use this for initialization
    void OnEnable()
    {
        wanderTimer = Random.Range(minVrijeme, maxVrijeme+1);
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            //gameObject.transform.LookAt(newPos);

           // Quaternion lookRotation = Quaternion.LookRotation(newPos);
           // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * damping);
            

            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
