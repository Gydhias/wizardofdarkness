using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public static PlayerMovement Instance;

    public float speedSprint = 12f;
    public float speed = 12f;
    public float Currentspeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float maxStamina = 100f;
    [Range(0,100)]public float stamina = 100f;
    public Slider slider;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
<<<<<<< HEAD
    Vector3 velocity;
    bool isGrounded;
    public float airControl;
    float control;
    
=======
    public Vector3 velocity;
    public bool isGrounded;
>>>>>>> WindSpells

    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    public void Update()
    {
        UseStamina(Input.GetKey(KeyCode.LeftShift));
        slider.value = stamina;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (!isGrounded)
        {
            control = airControl;
        }
        else
        {
            control = 1f;
        }
       if(isGrounded && velocity.y < 0) 
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * control + transform.forward * z * control;
      
        controller.Move(move * Currentspeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);
    }

    public void UseStamina(bool isRunning)
    {
        if (isRunning)
        {
            if (stamina > 0f)
            {
                stamina -= 15f * Time.deltaTime;
                Currentspeed = speedSprint;
            }
            else
            {
                Currentspeed = speed;
            }
        }
        else
        {
            if (stamina <= 30f)
            {
                stamina += 9f * Time.deltaTime;
            }

            else if (stamina < maxStamina)
            {
                stamina += 6f * Time.deltaTime;
            }
            Currentspeed = speed;

        }
    }


}
