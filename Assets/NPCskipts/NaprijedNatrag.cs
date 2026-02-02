using UnityEngine;

public class NaprijedNatrag : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Rigidbody rb;
    private bool goingToB;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.position = pointA.position;
        goingToB = true;
    }

    void FixedUpdate()
    {
        Vector3 target = goingToB ? pointB.position : pointA.position;

        Vector3 newPosition = Vector3.MoveTowards(
            rb.position,
            target,
            speed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPosition);

        // squared distance check = NO GC
        if ((rb.position - target).sqrMagnitude < 0.0025f)
        {
            goingToB = !goingToB;
        }
    }
}
