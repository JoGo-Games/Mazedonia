using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour
{
    public LevelController level;
    public float Velocity;
    [Space]
    private Vector3 initialPos;
    private int step;
    public bool reset;
    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation = 0.0f;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.0f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.0f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.0f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.0f;

    public float verticalVel;
    private Vector3 moveVector;

    // Use this for initialization
    void Start()
    {
        initialPos = gameObject.transform.position;
        anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reset)
        {
            InputMagnitude();
            isGrounded = controller.isGrounded;
            if (isGrounded)
            {
                verticalVel -= 0;
            }
            else
            {
                verticalVel -= 1;
            }
            moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
            controller.Move(moveVector);
        }
        if (reset)
        {
            float moving_step = Velocity * Time.deltaTime * 2.0f;
            switch (step)
            {
                case 1:
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 2.0f, transform.position.z), moving_step);
                        if (transform.position.y >= 2.0f - 0.05f)
                        {
                            transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
                            step = 2;
                        }
                        break;
                    }
                case 2:
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(initialPos.x, 2.0f, initialPos.z), moving_step);
                        if (((transform.position.x <= initialPos.x + 0.05f) && (transform.position.x >= initialPos.x - 0.05f)) && ((transform.position.z >= initialPos.z - 0.05f) && (transform.position.z <= initialPos.z + 0.05f)))
                        {
                            transform.position = new Vector3(initialPos.x, 2.0f, initialPos.z);
                            step = 3;
                        }
                        break;
                    }
                case 3:
                    {
                        transform.position = Vector3.MoveTowards(transform.position, initialPos, moving_step);
                        if (transform.position.y <= 0.0f + 0.05f)
                        {
                            transform.position = initialPos;
                            reset = false;
                        }
                        break;
                    }
            }
        }
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
        }
    }

    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }

    public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

    void InputMagnitude()
    {
        //Calculate Input Vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player

        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
        }
    }

    public void Restart_Position()
    {
        anim.SetFloat("Blend", 0.0f, 0.0f, Time.deltaTime);
        reset = true;
        step = 1;
    }
}
