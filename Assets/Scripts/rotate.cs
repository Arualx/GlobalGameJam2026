using UnityEngine;

public class rotate : MonoBehaviour
{
    public bool isFollow = false;

    private GameObject player;
    private HingeJoint hinge;
    private float speed = 15f;

    private PlayerDetector playerDetector;

    // NEW — delay before follow starts
    public float followDelay = 0.4f;
    private float followTimer = 0f;

    void Start()
    {
        playerDetector = GetComponentInChildren<PlayerDetector>();
        player = GameObject.FindGameObjectWithTag("Player");
        hinge = GetComponent<HingeJoint>();

        hinge.useMotor = true;
    }

    void Update()
    {
        if (!isFollow)
        {
            Rotate();
        }
        else
        {
            FollowWithHinge();
        }
    }

    private void Rotate()
    {
        JointMotor motor = hinge.motor;

        if (hinge.angle >= hinge.limits.max)
            motor.targetVelocity = -speed;
        else if (hinge.angle <= hinge.limits.min)
            motor.targetVelocity = speed;

        motor.force = 100f;
        hinge.motor = motor;
    }

    public void FollowPlayer()
    {
        isFollow = true;
        followTimer = 0f;
    }

    public void StopFollowingPlayer()
    {
        isFollow = false;
    }

    private void FollowWithHinge()
    {
        if (player == null) return;

        // delay before tracking
        followTimer += Time.deltaTime;
        if (followTimer < followDelay)
            return;

        Vector3 dir = player.transform.position - transform.position;

        // project direction onto hinge rotation plane
        Vector3 flatDir = Vector3.ProjectOnPlane(dir, hinge.axis);

        float targetAngle = Vector3.SignedAngle(
            transform.forward,
            flatDir,
            hinge.axis
        );

        JointMotor motor = hinge.motor;

        // smooth velocity toward target
        motor.targetVelocity = targetAngle * 3f;   // follow strength
        motor.force = 200f;

        hinge.motor = motor;
    }
}
