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

    [SerializeField] private GameObject pauseUI;
    [SerializeField] public static bool gameIsPaused;

    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private SphereCollider playerCollider;
    [SerializeField] private Animator playerAnimator;

    // Un comment when weapons are implemented
    [SerializeField] private Weapon playerWeapon;

    [SerializeField] private bool groundedPlayer = true;

    [SerializeField] private float health = 100.0f;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float fallYVel;

    [SerializeField] private float prevMaxXSpeed = 2.0f;

    [SerializeField] private float maxXSpeed = 2.0f;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float mass = 1.0f;

    private Vector3 prevPlayerMove;

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
        checkPause();
        updateMass();
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
            prevPlayerMove = move;

            playerAnimator.SetBool("Walk_Anim", true);
        }
        else
        {
            playerAnimator.SetBool("Walk_Anim", false);
        }

        if (playerAnimator.GetBool("Roll_Anim"))
        {
            move = prevPlayerMove / 10;
        }
        setVelocity(getVelocity() + (move * playerSpeed));

        if (rollWalkSwapControl.action.triggered)
        {
            swapMode();
        }

        if (jumpShootControl.action.triggered && groundedPlayer)
        {
            jump();
            groundedPlayer = false;
        }

        else if(jumpShootControl.action.triggered)
        {
            weaponJump();
        }

        fallYVel = getVelocity().y;
    }

    private void checkPause()
    {
        if(pauseControls.action.triggered)
        {
            PauseResumeGame();
        }
    }

    public void PauseResumeGame()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 1.0f;
            pauseUI.SetActive(false);
            gameIsPaused = false;
        }
        else
        {
            Time.timeScale = 0.0f;
            pauseUI.SetActive(true);
            gameIsPaused = true;
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
            StartCoroutine(rollSpeedChange());
        }
    }
    private IEnumerator rollSpeedChange()
    {
        if (playerAnimator.GetBool("Roll_Anim"))
        {
            yield return new WaitForSeconds(0.10f);
            maxXSpeed *= 2;

            yield return new WaitForSeconds(0.30f);
            maxXSpeed *= 2;
            prevMaxXSpeed = maxXSpeed;
        }
        else
        {
            yield return new WaitForSeconds(0.30f);
            maxXSpeed -= prevMaxXSpeed /= 2;

            yield return new WaitForSeconds(0.10f);
            maxXSpeed -= prevMaxXSpeed /= 2;
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

    private void weaponJump()
    {
        setVelocity(new Vector3(getVelocity().x, getVelocity().y + playerWeapon.useWeapon() * playerWeapon.getDamage(), getVelocity().z));
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
        //Debug.Log("Velocity: " + getRigidbody().velocity);
    }
    
    public Vector3 getVelocity()
    {
        return getRigidbody().velocity;
    }

    public void setHealth(float newHealth)
    {
        health = newHealth;
    }

    public void increaseHealth(float healthToAdd)
    {
        health += healthToAdd;
        if(health <= 0)
        {
            // Lose
            SceneManager.LoadScene("LoseGameScene");
        }
    }

    public float getHealth()
    {
        return health;
    }

    public void setMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }

    public void increaseMaxHealth(float maxHealthToAdd)
    {
        maxHealth += maxHealthToAdd;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public void setMass(float newMass)
    {
        mass = newMass;
    }

    public void increaseMass(float massToAdd)
    {
        mass += massToAdd;
    }

    public float getMass()
    {
        return mass;
    }

    public void setMaxSpeed(float newMaxSpeed)
    {
        maxXSpeed = newMaxSpeed;
    }

    public void increaseMaxSpeed(float maxSpeedToAdd)
    {
        maxXSpeed += maxSpeedToAdd;
    }

    public float getMaxSpeed()
    {
        return maxXSpeed;
    }

    public void setJumpHeight(float newJumpHeight)
    {
        jumpHeight = newJumpHeight;
    }

    public void increaseJumpHeight(float jumpHeightToAdd)
    {
        jumpHeight += jumpHeightToAdd;
    }

    public float getJumpHeight()
    {
        return jumpHeight;
    }

    public void setPlayerSpeed(float newPlayerSpeed)
    {
        playerSpeed = newPlayerSpeed;
    }

    public void increasePlayerSpeed(float playerSpeedToAdd)
    {
        playerSpeed += playerSpeedToAdd;
    }

    public float getPlayerSpeed()
    {
        return playerSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            Debug.DrawLine(transform.position, transform.position - playerCollider.bounds.extents - new Vector3(0.0f, 0.1f, 0.0f), Color.green, 3.0f);
            Debug.DrawLine(transform.position, transform.position + playerCollider.bounds.extents + new Vector3(0.0f, 0.1f, 0.0f), Color.green, 3.0f);

            if (collision.collider.bounds.Contains(transform.position - playerCollider.bounds.extents - new Vector3(0.0f, 0.1f, 0.0f))
                || collision.collider.bounds.Contains(transform.position + playerCollider.bounds.extents + new Vector3(0.0f, 0.1f, 0.0f)))
            {
                Debug.Log("Grounded Player");
                groundedPlayer = true;
                if(fallYVel <= -7.5f)
                {
                    increaseHealth(fallYVel * 2.5f);
                }
            }
        }
    }
}
