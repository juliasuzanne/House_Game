using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    //variable for amount of diamonds
    //
    [SerializeField]
    private bool flipping = true;
    [SerializeField]
    private float startingScale;
    [SerializeField]
    private float scaleAmount;
    [SerializeField]
    private GameObject floor;
    public float moveSpeed;
    float xInput, yInput, zInput;
    private RaycastHit2D hit;
    private Vector3 targetPos;
    SpriteRenderer sp;
    NavMeshAgent agent;
    private bool moveable = true;
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
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Start()
    {
        targetPos = transform.position;
        targetPos.z = 90f;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("PLAYER POS X, Y: (" + transform.position.x + ", " + transform.position.y + ")");
        // Debug.Log("TARGET POS: (" + targetPos.x + ", " + targetPos.y + ")");


        float ScaleValue = startingScale - (gameObject.transform.position.y / scaleAmount);

        gameObject.transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        targetPos.z = 90f;
        if (Input.GetMouseButtonDown(0) && moveable == true)//if mouse is clicked
        {

            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        ClickToMove();
        // if (moveable == true)
        // {
        //     transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);
        //     PlatformerMove();
        //     FlipPlayer();
        //     animator.SetFloat("ySpeed", (moveSpeed * yInput));
        //     animator.SetFloat("xSpeed", Mathf.Abs(moveSpeed * xInput));
        // }
        // Debug.Log("MOVEABLE: " + moveable);
        // Debug.Log("TargetPos " + targetPos);
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



        if (moveable == true && !EventSystem.current.IsPointerOverGameObject())
        {
            hit = Physics2D.Raycast(targetPos, Vector2.zero);
            Debug.Log("hit: " + hit.collider.name);

            float xDistance = (targetPos.x - transform.position.x);
            float yDistance = (targetPos.y - transform.position.y);
            if (flipping == true)
            {
                if (xDistance < 0)
                {
                    sp.flipX = false;
                }
                else
                {
                    sp.flipX = true;
                }
            }
            animator.SetFloat("ySpeed", Mathf.Abs(yDistance));
            animator.SetFloat("ySpeedDir", yDistance);
            animator.SetFloat("xSpeed", Mathf.Abs(xDistance));
            agent.SetDestination(new Vector3(targetPos.x, targetPos.y, transform.position.z));


            // Debug.Log("X: " + xDistance + " Y: " + yDistance);



            // && !EventSystem.current.IsPointerOverGameObject()

            if (hit.collider.name != "Floor")
            {
                targetPos = transform.position;
            }

            // transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * 1000 * Time.deltaTime);
            // if (collided == true || moveable == false)
            // {
            //     Cursor.visible = true;
            //     animator.SetFloat("ySpeed", (0));
            //     animator.SetFloat("xSpeed", (0));
            //     targetPos = transform.position;

            // }

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

