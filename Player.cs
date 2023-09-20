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
    private Vector2 targetPos;
    SpriteRenderer sp;
    private bool moveable = true;
    private bool collided = false;
    Rigidbody2D rb;
    private Animator animator;
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
    }

    // Update is called once per frame
    void Update()
    {


        // mousePos.z = 0f;

        if (Input.GetMouseButtonDown(0))//if mouse is clicked
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        ClickToMove();
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
        RaycastHit2D hit = Physics2D.Raycast(targetPos, Vector2.zero);
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
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            if (collided == true)
            {
                animator.SetFloat("ySpeed", (0));
                animator.SetFloat("xSpeed", Mathf.Abs(0));
                targetPos = transform.position;

            }

        }
        else
        {
            Debug.Log("Hit Collider = " + hit.collider.name);
        }


    }


}

