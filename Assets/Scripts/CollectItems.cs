using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private LayerMask layerHit; 
    private Material myMat1;
    private Material myMat2;
    private Material myMat3;

    private void Start()
    {
        myMat1 = transform.GetChild(0).GetComponent<Renderer>().materials[0];
        myMat1.SetFloat("_outlineScale", 0f);

        myMat2 = transform.GetChild(1).GetComponent<Renderer>().materials[0];
        myMat2.SetFloat("_outlineScale", 0f);

        myMat3 = transform.GetChild(2).GetComponent<Renderer>().materials[0];
        myMat3.SetFloat("_outlineScale", 0f);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(ray, out hit, 4f, layerHit))
                {
                    gameManager.CollectedUSB++;
                    if(gameObject.name == "USBGreen") gameManager.CollectedGreenUSB++;
                    else if (gameObject.name == "USBBlue") gameManager.CollectedBlueUSB++;
                    else if (gameObject.name == "USBRed") gameManager.CollectedRedUSB++;  
                    Destroy(gameObject);
                }
                
            }

            myMat1.SetFloat("_outlineScale", 1.08f);
            myMat2.SetFloat("_outlineScale", 1.08f);
            myMat3.SetFloat("_outlineScale", 1.08f);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myMat1.SetFloat("_outlineScale", 0f);
            myMat2.SetFloat("_outlineScale", 0f);
            myMat3.SetFloat("_outlineScale", 0f);

        }
    }
}
