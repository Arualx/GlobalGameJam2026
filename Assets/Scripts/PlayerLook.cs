using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    public Transform orientation;

    public float mouseSensX = 500;
    public float mouseSensY = 500;
    private float yRotation;
    private float xRotation;

    private Vector3 camOffset;
    private float CamSpeed;
    private float CamAmount;

    private PlayerMovement player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
        
        if (player.playerRunning)
        {
            CamSpeed = 10f;
            CamAmount = 0.25f;
            HeadMovement();
        }
        else
        {
            CamSpeed = 5f;
            CamAmount = 0.1f;
            StopHeadMovement();
        }

        UpdateCam();
    }

    private void UpdateCam()
    {
        transform.position = cameraPosition.position + camOffset;
    }

    public void HeadMovement()
    {
        camOffset.y = Mathf.Sin(Time.time * CamSpeed) * CamAmount;

    }

    public void StopHeadMovement()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) < 0.001f) return;
        camOffset = Vector3.Lerp(camOffset, Vector3.zero, 5f * Time.deltaTime);
    }     
}
