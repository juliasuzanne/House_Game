using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private float h_speed = 1;
    [SerializeField]
    private int _jumpForce = 5;
    [SerializeField]
    private float _moveSpeed = 2f;
    private bool falling = false;
    private bool moveable = false;
    private bool _grounded = false;

    Rigidbody2D rb;
    SpriteRenderer sp;
    private Animator animator;
    float xInput, yInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();


    }
    void FlipPlayer()
    {
        if (xInput < -0.0001f)
        {
            sp.flipX = false;

        }
        else if (xInput > 0.0001f)
        {
            sp.flipX = true;
        }
    }
    public void MoveableFalse()
    {
        moveable = false;
    }

    public void MoveableTrue()
    {
        moveable = true;
    }


    void PlatformerMove()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _jumpForce);
        }


        if (moveable == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
            {
                yInput = _jumpForce;

                Debug.Log("space key down");

            }
            else
            {
                yInput = -1.2f;
                // yInput = Input.GetAxis("Vertical");

            }
            animator.SetFloat("ySpeed", yInput);
            animator.SetFloat("xSpeed", Mathf.Abs(xInput));

            rb.velocity = new Vector2(_moveSpeed * xInput, yInput);


        }
        //keeping y velocity the same, but modifying
        else
        {
            Cursor.visible = true;
            animator.SetFloat("ySpeed", yInput);
            animator.SetFloat("xSpeed", Mathf.Abs(xInput));

            // hit = Physics2D.Raycast(targetPos, Vector2.zero);
            // Debug.Log("hit: " + hit.collider.name);
            // Debug.Log("Hit Collider = " + hit.collider.name);
        }

    }

    // public void ChangeFallingBool()
    // {
    //     if (falling == true)
    //     {
    //         falling = false;
    //     }
    //     else
    //     {
    //         falling = true;
    //         moveable = true;

    //     }
    // }

    void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 6.0f, 1 << 12);
        Debug.DrawRay(transform.position, -Vector2.up, Color.green);

        if (hit.collider != null)
        {

            _grounded = true;
        }
        else
        {
            _grounded = false;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Broom")
        {
            moveable = true;

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.name == "Broom")
        {
        }
    }


    // public void Jump(bool jump)
    // {
    //     animator.SetBool("Jump", !jump);
    // }


    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        FlipPlayer();
        PlatformerMove();
        CheckGrounded();
        Debug.Log("Grounded = " + _grounded);

        // if (falling == true)
        // {
        //     transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        // }




    }
}
