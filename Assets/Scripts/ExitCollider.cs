using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public bool PlayerFinished = false;
    public GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManager.USBInserted)
        {
            PlayerFinished = true;
        }
    }
}
