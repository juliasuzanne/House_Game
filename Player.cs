using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    float xInput, yInput, zInput;
    Vector2 targetPos;
    SpriteRenderer sp;
    Rigidbody2D rb;
    public Animator animator;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         //in screen coordinates, need to convert
        mousePos.z = 10f;
        //z value needs to be a little bit forward from the camera so that we can see it through the camera?
        if (Input.GetMouseButtonDown(0))//if mouse is clicked
        {
            targetPos = mousePos;
        }

        //transform.position = mousePos;
        //setting player position to the mousePos

        //Debug.Log("mouse" + mousePos);

    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);
        //ClickToMove();
        PlatformerMove();
        FlipPlayer();
        animator.SetFloat("ySpeed", (moveSpeed * yInput));
        animator.SetFloat("xSpeed", Mathf.Abs(moveSpeed * xInput));
        //Debug.Log("x:" + xInput);
        //Debug.Log("y:" + yInput);
    }

    void ClickToMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
        //keeping y velocity the same, but modifying
        
    }

    void FlipPlayer()
    {
        if(rb.velocity.x < -0.1f){
            sp.flipX = false;

        }
        else if(rb.velocity.x > 0.1f)
        {
            sp.flipX = true;
        }
    }
}
