using UnityEngine;

public class StartGame : MonoBehaviour
{
    private DisplayText display;
    private void Start()
    {
        display = GameObject.Find("Canvas").GetComponent<DisplayText>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            display.PlayerStarted = true;
            Destroy(this.gameObject);
        }
    }
}
