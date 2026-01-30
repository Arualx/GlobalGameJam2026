using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private float speed = 3.0f;
    private int currentPatrolIndex = 0;
    private void Update()
    {
        if (patrolPoints.Length == 0) return;
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void DetectPlayer()
    {
        // Placeholder for player detection logic
    }



}

