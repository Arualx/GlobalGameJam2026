using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public int CollectedUSB;
    public int CollectedBlueUSB;
    public int CollectedRedUSB;
    public int CollectedGreenUSB;
    public bool USBInserted;

    private float alertLevel = 0.0f;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }


    }


    public void IncreaseAlertLevel()
    {
        alertLevel += 10 * Time.deltaTime;
        alertLevel = Mathf.Clamp(alertLevel, 0.0f, 100.0f);
    }

    public void DecreaseAlertLevel()
    {
        alertLevel -= 5 * Time.deltaTime;
        alertLevel = Mathf.Clamp(alertLevel, 0.0f, 100.0f);
    }





}

