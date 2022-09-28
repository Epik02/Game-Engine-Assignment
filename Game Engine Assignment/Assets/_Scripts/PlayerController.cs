using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    //Player Movement
    public PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    private float walkSpeed = 5f;
    // public Camera playerCamera;
    //Vector3 cameraRotation;

    //Player Jump
    Rigidbody rb; //rigid body
    private float distanceToGround;
    private bool isGrounded = true;
    public float jump = 5f;

    //Player Animation
    Animator playerAnimator;
    private bool isWalking = false;

    //Projectile Bullets
    public GameObject bullet;
    public Transform projectilePos;

    GameObject clone;
    public PlayerController player;
    public float playerx = 0;
    public float playery = 0;
    public float playerz = 0;

    public Animator pAnimator;
    public Rigidbody mplayer;

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }
    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();
        inputAction.Player.Shoot.performed += cntxt => Shoot();

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

    }

    void IsMoving()
    {
        if (mplayer.velocity.magnitude != 0)
        {
            pAnimator.SetBool("walk", true);
        }
        else
        {
            pAnimator.SetBool("walk", false);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }

    //public void Shoot()
    //{
    //    Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
    //    bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
    //    bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    //    Destroy(bulletRb, 1.0f);
    //}
    public void Shoot()
    {
        clone = Instantiate(bullet, projectilePos.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * 32f, ForceMode.Impulse);
        clone.GetComponent<Rigidbody>().AddForce(transform.up * 5f, ForceMode.Impulse);
        Destroy(clone, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);

        playerx = transform.position.x;
        playery = transform.position.y;
        playerz = transform.position.z;

        if (playery <= -10 || playerx >= 286)
        {
            SceneManager.LoadScene("Level1");
        }
        IsMoving();
    }
}