using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    private void IncreaseAlertLevel(float amount)
    {
        alertLevel += amount;
        alertLevel = Mathf.Clamp(alertLevel, 0.0f, 100.0f);
    }

    private void DecreaseAlertLevel(float amount)
    {
        alertLevel -= amount;
        alertLevel = Mathf.Clamp(alertLevel, 0.0f, 100.0f);
    }

    

}

