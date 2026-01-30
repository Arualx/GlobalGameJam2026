using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private float stamina = 100f;
    private float staminaTimer;
    private Slider staminaBar;

    private float playerSpeed;
    private float playerRunSpeed = 5f;
    private float playerWalkSpeed = 3f;

    private float groundDrag = 6f;
    private bool isGrounded = false;
    public LayerMask groundLayer;

    private Rigidbody rb;

    private bool playerRunning = false;

    private float moveHorizontal;
    private float moveVertical;
    public Transform orientation;
    private Vector3 MovementDirection;


    void Start()
    {
        staminaBar = GameObject.Find("StaminaMeter").GetComponent<Slider>();
        staminaBar.value = stamina;
        rb = GetComponent<Rigidbody>();
        
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
        

    }

    
    

    private void HeadMovement()
    {

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
