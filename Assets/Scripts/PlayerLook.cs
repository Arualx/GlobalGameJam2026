using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform orientation;

    public float mouseSensX = 500;
    public float mouseSensY = 500;
    private float yRotation;
    private float xRotation;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
