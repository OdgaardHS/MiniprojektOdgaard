using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Unity CharacterController
    public CharacterController characterController;
    float speed = 10f;
    float jumpSpeed = 7f;

    //Gravity
    float gravity = 16;
    float verticalSpeed = 0;

    //Rotate with mouse
    public Transform CameraHolder;
    float mouseSensitivity = 1f;
    float upLimit = -80;
    float downLimit = 80;

    //Sprint
    public Image staminaImage;
    public static float stamina = 1f;
    public static float maxStamina = 1f;
    float staminaRecoveryDelay;
    bool isSprinting = false;

    private void Start(){
        //Makes the cursor be locked in the middle of the screen, with its visibility disabled. so that it does not block the view of the crosshair
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //calls the functions from down below
        Move();
        Rotate();
        Sprint();
    }
    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            verticalSpeed = -2f;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            verticalSpeed = jumpSpeed;
        }
        //Adds gravity
        Vector3 GravityMove = new Vector3(0, verticalSpeed, 0);

        Vector3 Move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(speed * Time.deltaTime * Move + GravityMove * Time.deltaTime);
    }

    public void Rotate()
    {
        float HorizontalRotation = Input.GetAxis("Mouse X");
        float VerticalRotation = Input.GetAxis("Mouse Y");
        //rotates the camera and the player
        transform.Rotate(0, HorizontalRotation * mouseSensitivity, 0);
        CameraHolder.Rotate(-VerticalRotation * mouseSensitivity, 0, 0);

        Vector3 CurrentRotation = CameraHolder.localEulerAngles;

        if (CurrentRotation.x > 180)
        {
            CurrentRotation.x -= 360;
        }
        //stops the player from looking too far up and down
        CurrentRotation.x = Mathf.Clamp(CurrentRotation.x, upLimit, downLimit);
        CameraHolder.localRotation = Quaternion.Euler(CurrentRotation);
    }

    public void Sprint()
    {
        //allows the use of sprinting with the shift key, if any stamina is left
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = 30f;
            stamina -= 0.2f * Time.deltaTime;
            isSprinting = true;
            staminaImage.fillAmount -= 0.2f * Time.deltaTime;
        }
        else if (stamina < 0 || Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (isSprinting == true)
            {
                speed = 7f;
                isSprinting = false;
                staminaRecoveryDelay = Time.time;
            }
        }
        //Allows stamina to recover over time, when not sprinting
        if (isSprinting == false && stamina < maxStamina && Time.time > (staminaRecoveryDelay + 1f))
        {
            stamina += 0.2f * Time.deltaTime;
            staminaImage.fillAmount += 0.2f * Time.deltaTime;
        }
        
    }
}
