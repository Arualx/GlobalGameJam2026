using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DisplayText : MonoBehaviour
{
    public PlayerMovement player;
    public Image death;
    public float duration = 3f;
    public GameObject DeathText;
    public bool PlayerStarted = false;
    private ExitCollider ExitCollider;
    public bool EnemiesBroken = false;
    IEnumerator FadeIn()
    {
        float t = 0f;
        Color c = death.color;

        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / duration);
            death.color = c;
            yield return null;
        }

        c.a = 1f;
        death.color = c;

        DeathText.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
        

    }

    public GameManager gameManager;
    public TextMeshProUGUI quest;
    private string message1 = "Collect all the USB sticks containing virus. ";
    private string message2 = "Put the USB sticks in the main server.";
    private string message3 = "Explore the area and blend in.";
    private string message4 = "Escape the building.";

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        quest = GameObject.Find("GivenQuests").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        ExitCollider = GameObject.Find("ExitCollider").GetComponent<ExitCollider>();

        quest.text = message3;
    }

    void Update()
    {
        if (player.PlayerDead)
        {
            death = GameObject.Find("DeathMenu").gameObject.GetComponent<Image>();
            DeathText = GameObject.Find("DeathMenu").transform.GetChild(0).gameObject;
            StartCoroutine(FadeIn());
        }
        else if (ExitCollider.PlayerFinished)
        {
            death = GameObject.Find("EscapeMenu").gameObject.GetComponent<Image>();
            DeathText = GameObject.Find("EscapeMenu").transform.GetChild(0).gameObject;
            StartCoroutine(FadeIn());
        }


        if (!PlayerStarted)
        {
            quest.text = message3;
        }
        else if (gameManager.CollectedUSB < 9)
        {
            quest.text = message1 + "\n" +
                         gameManager.CollectedBlueUSB + "/3 blue USB sticks collected.\n" +
                         gameManager.CollectedGreenUSB + "/3 green USB sticks collected.\n" +
                         gameManager.CollectedRedUSB + "/3 red USB sticks collected.\n";
        }
        else if (gameManager.CollectedUSB >= 9 && !gameManager.USBInserted)
        {
            PlayerStarted = true;
            quest.text = message2;
        }
        else if (gameManager.USBInserted)
        {
            quest.text = message4;
        }


    }

}
