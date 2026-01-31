using UnityEngine;

public class ReflectorMovement : MonoBehaviour
{
    private float alertLevel = 0.0f;
    private float rotationSpeed = 50f;
    void Update()
    {

    }

    public void IncreaseAlertLevel()
    {
        alertLevel += 10f * Time.deltaTime;
        alertLevel = Mathf.Clamp(alertLevel, 0.0f, 100.0f);
    }

    public void DecreaseAlertLevel()
    {
        alertLevel -= 10f * Time.deltaTime;
        alertLevel = Mathf.Clamp(alertLevel, 0.0f, 100.0f);
    }

}
