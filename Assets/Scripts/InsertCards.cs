using UnityEngine;

public class InsertCards : MonoBehaviour
{
    private Material myMat;
    private GameObject USBCards;
    private int ThisColor = 0;
    private bool ServerUpgrade = false;
    public GameManager gameManager;
    [SerializeField] private LayerMask layerHit;

    private void Start()
    {
        myMat = GetComponent<Renderer>().materials[0];
        myMat.SetFloat("_outlineScale", 0f);
        USBCards = transform.GetChild(0).gameObject;
        USBCards.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (this.gameObject.name == "ServerRed") ThisColor = gameManager.CollectedRedUSB;
        else if (this.gameObject.name == "ServerGreen") ThisColor = gameManager.CollectedGreenUSB;
        else if (this.gameObject.name == "ServerBlue") ThisColor = gameManager.CollectedBlueUSB;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!ServerUpgrade && ThisColor == 3) myMat.SetFloat("_outlineScale", 1.08f);
            if (Input.GetMouseButton(0) && ThisColor == 3 && !ServerUpgrade)
            {
                if (Physics.Raycast(ray, out hit, 10f, layerHit))
                {
                    USBCards.SetActive(true);
                    gameManager.USBInserted = true;
                    ServerUpgrade = true;
                }

            }
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myMat.SetFloat("_outlineScale", 0f);
        }
    }


}
