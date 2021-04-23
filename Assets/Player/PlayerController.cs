using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference jumpShootControl;
    [SerializeField] private InputActionReference rollWalkSwapControl;
    [SerializeField] private InputActionReference pauseControls;

    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private SphereCollider playerCollider;
    [SerializeField] private Animator playerAnimator;

    // Un comment when weapons are implemented
    //[SerializeField] private Weapon playerWeapon;

    [SerializeField] private bool groundedPlayer = true;
    [SerializeField] private bool rolling = false;
    [SerializeField] private bool opening = false;

    [SerializeField] private float maxXSpeed = 2.0f;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float mass = 1.0f;

    [SerializeField] private float swapTimerCooldown = 5.0f;
    [SerializeField] private float swapTimer = 0.0f;

    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpShootControl.action.Enable();
        pauseControls.action.Enable();
        rollWalkSwapControl.action.Enable();
    }

    private void OnDisable()
    {
        
        movementControl.action.Disable();
        jumpShootControl.action.Disable();
        pauseControls.action.Disable();
        rollWalkSwapControl.action.Disable();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //updateMass();
        move();
    }

    private void move()
    {
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0.0f, 0.0f);

        //Debug.Log("Movement: " + movement);
        //Debug.Log("Move: " + move);

        move = Camera.main.transform.forward * move.z + Camera.main.transform.right * move.x;
        move.y = 0.0f;
        move.z = 0.0f;

        if (move != Vector3.zero)
        {
            transform.forward = move;
            playerAnimator.SetBool("Walk_Anim", true);
        }
        else
        {
            playerAnimator.SetBool("Walk_Anim", false);
        }

        setVelocity(getVelocity() + move);

        if (rollWalkSwapControl.action.triggered)
        {
            swapMode();
        }

        if (jumpShootControl.action.triggered && groundedPlayer)
        {
            jump();
        }
    }

    private void swapMode()
    {
        if (swapTimer <= 0.0f)
        {
            if (playerAnimator.GetBool("Open_Anim"))
            {
                playerAnimator.SetBool("Open_Anim", false);
                playerAnimator.SetBool("Roll_Anim", true);
            }
            else
            {
                playerAnimator.SetBool("Open_Anim", true);
                playerAnimator.SetBool("Roll_Anim", false);
            }
            StartCoroutine(lowerSwapTimer());
        }
    }

    private IEnumerator lowerSwapTimer()
    {
        swapTimer = swapTimerCooldown;
        while(swapTimer > 0.0f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            swapTimer -= Time.deltaTime;
        }
        swapTimer = 0.0f;
    }

    private void updateMass()
    {
        getRigidbody().mass = mass;
    }

    private void jump()
    {
        setVelocity(new Vector3(getVelocity().x, getJumpHeight(), getVelocity().z));
    }

    public Rigidbody getRigidbody()
    {
        return playerRigidBody;
    }

    public void setVelocity(Vector3 newVelocity)
    {
        if (newVelocity.x > maxXSpeed)
            newVelocity.x = maxXSpeed;

        else if (newVelocity.x < -maxXSpeed)
            newVelocity.x = -maxXSpeed;

        getRigidbody().velocity = newVelocity;
        Debug.Log("Velocity: " + getRigidbody().velocity);
    }
    
    public Vector3 getVelocity()
    {
        return getRigidbody().velocity;
    }

    public void setJumpHeight(float newJumpHeight)
    {
        jumpHeight = newJumpHeight;
    }

    public float getJumpHeight()
    {
        return jumpHeight;
    }

    public void setPlayerSpeed(float newPlayerSpeed)
    {
        playerSpeed = newPlayerSpeed;
    }

    public float getPlayerSpeed()
    {
        return playerSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.collider.CompareTag("Ground"))
        //{
        //    //playerCollider.bounds.extents.y
        //}
    }
}
