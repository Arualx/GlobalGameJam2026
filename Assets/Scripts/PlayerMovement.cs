using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float health = 100f;
    private Slider healthBar;

    private float stamina = 100f;
    private float staminaTimer;
    private Slider staminaBar;

    private float playerSpeed;
    private float playerRunSpeed = 8f;
    private float playerWalkSpeed = 5f;

    private float groundDrag = 6f;
    private bool isGrounded = false;
    public LayerMask groundLayer;

    private Rigidbody rb;

    public bool playerRunning = false;

    private float moveHorizontal;
    private float moveVertical;
    public Transform orientation;
    private Vector3 MovementDirection;

    public PlayerLook playerLook;
    public bool PlayerDead;

    void Start()
    {
        healthBar = GameObject.Find("HealthMeter").GetComponent<Slider>();
        staminaBar = GameObject.Find("StaminaMeter").GetComponent<Slider>();
        staminaBar.value = stamina;
        rb = GetComponent<Rigidbody>();
        playerLook = GameObject.Find("Main Camera").GetComponent<PlayerLook>();
    }

    //player movement
    private void PlayerInput()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }
    
    private void PlayerMove()
    {
        MovementDirection = orientation.forward * moveVertical + orientation.right * moveHorizontal;
        rb.AddForce(MovementDirection.normalized * playerSpeed * 10f, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void Update()
    {
        PlayerInput();

        //ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f, groundLayer);
        if (isGrounded) rb.linearDamping = groundDrag;
        else rb.linearDamping = 0f;

        
        if (Input.GetKey(KeyCode.LeftShift) && staminaBar.value > 0.0f && MovementDirection.magnitude > 0f)
        {
            playerSpeed = playerRunSpeed;
            playerRunning = true; 
        }
        else
        {
            playerSpeed = playerWalkSpeed;
            playerRunning = false;
        }
        
        
        if (playerRunning)
        {
            DecreaseStamina();
        }
        else
        {
            if (staminaTimer > 0f)
            {
                staminaTimer -= Time.deltaTime;
            }
            else
            {
                IncreaseStamina();
            }
        }
        
        if (MovementDirection.magnitude > 0f)
        {
            playerLook.HeadMovement();
        }
        else
        {
            playerLook.StopHeadMovement();
        }

    }

    public void TakeDamage()
    {
        Debug.Log("Player Took Damage");
        health -= 10f;
        health = Mathf.Clamp(health, 0.0f, 100.0f);
        healthBar.value = health;
        if (healthBar.value < 0.0f) PlayerDead = true;
    }

    
    private void IncreaseStamina()
    {
        
        if (stamina < 100.0f && staminaTimer <= 0f)
        {
            
            stamina += 10.0f * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, 0.0f, 100.0f);
            staminaBar.value = stamina;
        }
    }

    private void DecreaseStamina()
    {
        stamina -= 10.0f * Time.deltaTime;
        stamina = Mathf.Clamp(stamina, 0.0f, 100.0f);
        staminaTimer = 3.0f;
        staminaBar.value = stamina;
    }
}
