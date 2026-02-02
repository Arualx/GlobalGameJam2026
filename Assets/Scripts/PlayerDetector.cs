using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool isInside = false;
    private Transform playerTransform;
    private GameManager gameManager;
    private rotate rotate;  
    private void Start()
    {
        rotate = GetComponentInParent<rotate>();
        playerTransform = GameObject.Find("Player").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //make code so plejer skerjd
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
            isInside = true;
            gameManager.IncreaseAlertLevel();
            rotate.FollowPlayer();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = false;
            Debug.Log("Player Left Detection Area");
            gameManager.DecreaseAlertLevel();
            rotate.StopFollowingPlayer();
        }
    }

}
