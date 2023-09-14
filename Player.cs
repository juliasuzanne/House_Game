using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    float xInput, yInput, zInput;

    [SerializeField]
    private float scaleYStart = -1f;

    [SerializeField]
    private float scaler = 0.3f;

    private Vector3 scale_changer;
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
        scale_changer = new Vector3(scaler, scaler, 0);
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
        // ClickToMove();
        PlatformerMove();
        FlipPlayer();
        // if (transform.position.y > scaleYStart)
        // {
        //     moveSpeed = 0.05f;
        //     StartCoroutine("ScalePlayer");
        // }
        // else
        // {
        //     moveSpeed = 0.1f;}


        animator.SetFloat("ySpeed", (moveSpeed * yInput));
        animator.SetFloat("xSpeed", Mathf.Abs(moveSpeed * xInput));
        //Debug.Log("x:" + xInput);
        //Debug.Log("y:" + yInput);


    }

    void ClickToMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // animator.SetFloat("ySpeedClick", (pos0y - pos1y));
        // animator.SetFloat("xSpeedClick", Mathf.Abs(pos0x - pos1x));

    }

    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
        //keeping y velocity the same, but modifying x


    }

    void FlipPlayer()
    {
        if (rb.velocity.x < -0.01f)
        {
            sp.flipX = false;

        }
        else if (rb.velocity.x > 0.01f)
        {
            sp.flipX = true;
        }
    }

    // IEnumerator ScalePlayer()
    // {
    //     yInput = Input.GetAxis("Vertical");
    //     float pos0 = transform.position.y;
    //     yield return new WaitForSeconds(0.2f);
    //     float pos1 = transform.position.y;
    //     if (Mathf.Abs(pos1 - pos0) > 0.5)
    //     {
    //         transform.localScale -= scale_changer * yInput;

    //     }
    // }
}

