using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rgd2 = GetComponent<Rigidbody2D>();
    }

    private Animator anim;

    private Rigidbody2D rgd2;

    //running
    public float speed = 5f;

    private float moveInput;

    public float crunchSpeed;

    //ground check
    public bool isGround;

    public Transform groundCheck;

    public float checkRadius;

    public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        moveInput = Input.GetAxis("Horizontal");
        rgd2.velocity = new Vector2(moveInput * speed, rgd2.velocity.y);

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (moveInput != 0 && isGround)
        {
            anim.SetBool("isRunning", true);
        }
        else if (moveInput == 0 && isGround)
        {
            anim.SetBool("isRunning", false);
        }
    }
}
