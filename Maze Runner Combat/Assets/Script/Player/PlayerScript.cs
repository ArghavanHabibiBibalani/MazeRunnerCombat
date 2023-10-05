using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] Animator PlayerAnimation;

    [SerializeField] float playerSpeed = 0.5f;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float rotationSpeed = 5f;

    private float moveHorizontal;
    private float moveVertical;
    private float rotaionY = 0f;

    private bool isMoving;
    private bool canJump;

    public LayerMask groundLayer;
    public Transform groundCheack;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
    }

    void Start()
    {
        rotaionY = transform.localRotation.eulerAngles.y; // it just takes the child's rotation and rotation it in just Y direction
    }

    void Update()
    {
        PlayerMoveInputWithKeybord();
        AnimateThePlayer();

    }

    private void FixedUpdate()
    {
        MovementAndRotationOfPlayer();
    }

    void PlayerMoveInputWithKeybord()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveHorizontal = -1;
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveHorizontal = 0;
        }
        if (Input.GetMouseButtonDown(1))
        {
            moveHorizontal = 1;
        }
        if (Input.GetMouseButtonUp(1))
        {
            moveHorizontal = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveVertical = 1;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveVertical = 0;
        }
    }

    void MovementAndRotationOfPlayer()
    {
        if (moveVertical != 0)
        {
            playerRigidBody.MovePosition(transform.position + transform.forward * moveVertical * playerSpeed);
        }

        rotaionY += moveHorizontal * rotationSpeed;
        playerRigidBody.rotation = Quaternion.Euler(0f, rotaionY, 0f);

    }

    void AnimateThePlayer()
    {
        if(moveVertical != 0)
        {
            if (!isMoving)
            {
                if(!PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName(States.RunAnimation)) //in first layer of animator we map to run tag in animator with "State" class.
                {
                    isMoving = true;
                    PlayerAnimation.SetTrigger(States.RunTrigger); //our player is in run animation
                }
            }
        }
        else
        {
            if (isMoving)
            {
                if (PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName(States.RunAnimation))
                {
                    isMoving = false;
                    PlayerAnimation.SetTrigger(States.StopTrigger); //our player stopped.
                }
            }
        }
    }

    //void Attack()
    //{
    //    if(Input.GetButtonDown)
    //}
}
