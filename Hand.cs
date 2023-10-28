using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 2f;
    private bool falling = false;
    private bool moveable = false;
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
        if (moveable == true)
        {
            rb.velocity = new Vector2(_moveSpeed * xInput, yInput);
            animator.SetFloat("ySpeed", yInput);
            animator.SetFloat("xSpeed", Mathf.Abs(xInput));

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

    public void ChangeFallingBool()
    {
        if (falling == true)
        {
            falling = false;
        }
        else
        {
            falling = true;
            moveable = true;

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name);
        // if (other.name == "Broom")
        // {
        //     ChangeFallingBool();

        // }
    }



    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        FlipPlayer();
        PlatformerMove();
        Debug.Log("Falling = " + falling);

        if (falling == true)
        {
            transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        }

    }
}
