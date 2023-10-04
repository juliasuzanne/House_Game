using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    //variable for amount of diamonds
    //
    public float moveSpeed;
    float xInput, yInput, zInput;
    private RaycastHit2D hit;
    private Vector3 targetPos;
    SpriteRenderer sp;
    private bool moveable = false;
    private bool collided = false;
    Rigidbody2D rb;
    private Animator animator;
    private GameObject dialogue;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = transform.GetComponent<Animator>();
    }
    void Start()
    {

        targetPos = transform.position;
        targetPos.z = 90f;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("MOveable is " + moveable);
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");



        targetPos.z = 90f;

        // if (Input.GetMouseButtonDown(0) && moveable == true)//if mouse is clicked
        // {
        //     targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // }
        // ClickToMove();


        if (moveable == true)
        {
            transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);
            PlatformerMove();
            FlipPlayer();
            animator.SetFloat("ySpeed", (moveSpeed * yInput));
            animator.SetFloat("xSpeed", Mathf.Abs(moveSpeed * xInput));
        }


        Debug.Log("MOVEABLE: " + moveable);
        Debug.Log("TargetPos " + targetPos);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        collided = true;
        Debug.Log("collision" + other.gameObject.name);

    }

    void OnCollisionExit2D(Collision2D other)
    {
        collided = false;
    }

    public void MoveableFalse()
    {
        moveable = false;
    }

    public void MoveableTrue()
    {
        moveable = true;
    }

    void ClickToMove()
    {
        if (moveable == true)
        {
            hit = Physics2D.Raycast(targetPos, Vector2.zero);

        }
        if (hit.collider.name == "flooronly" && !EventSystem.current.IsPointerOverGameObject() && moveable == true)
        {
            float xDistance = (targetPos.x - transform.position.x);
            float yDistance = (targetPos.y - transform.position.y);
            // Debug.Log("X: " + xDistance + " Y: " + yDistance);
            if (xDistance < 0)
            {
                sp.flipX = false;
            }
            else
            {
                sp.flipX = true;

            }
            animator.SetFloat("ySpeed", (yDistance));
            animator.SetFloat("xSpeed", Mathf.Abs(xDistance));
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            if (collided == true || moveable == false)
            {
                Cursor.visible = true;
                animator.SetFloat("ySpeed", (0));
                animator.SetFloat("xSpeed", Mathf.Abs(0));
                targetPos = transform.position;

            }

        }
        else
        {
            Cursor.visible = true;

            Debug.Log("Hit Collider = " + hit.collider.name);
        }


    }







    void PlatformerMove()
    {
        if (moveable == true)
        { rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y); }
        //keeping y velocity the same, but modifying
        else
        {
            Cursor.visible = true;

            Debug.Log("Hit Collider = " + hit.collider.name);
        }

    }

    void FlipPlayer()
    {
        if (rb.velocity.x < -0.0001f)
        {
            sp.flipX = false;

        }
        else if (rb.velocity.x > 0.0001f)
        {
            sp.flipX = true;
        }
    }

}

