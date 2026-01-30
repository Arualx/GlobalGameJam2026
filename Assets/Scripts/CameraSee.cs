using UnityEngine;

public class CameraSee : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
