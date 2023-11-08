using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandMirror : MonoBehaviour
{
    private Image im;
    private Color m_NewColor;
    float m_Red, m_Blue, m_Green;
    [SerializeField]
    private float _moveSpeed = 2f;
    [SerializeField]
    private Slider redSlider;

    private Hand _playerScript;
    [SerializeField]
    private Slider blueSlider;
    Rigidbody2D rb;
    SpriteRenderer sp;
    SpriteRenderer spEye;
    private PickColor _pickColorScript;
    private Animator animator;
    float xInput, yInput;
    float startingXPos, startingYPos, xZero, yZero, xOne, yOne;

    [SerializeField]
    private Slider greenSlider;
    // Start is called before the first frame update
    void Start()
    {
        im = transform.GetComponent<Image>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        // animator = transform.GetComponent<Animator>();
        startingXPos = transform.position.x;
        startingYPos = transform.position.y;
        xZero = startingXPos - 6.15f;
        yZero = startingYPos - 2.25f;
        xOne = startingXPos + 6.15f;
        yOne = startingYPos + 2.25f;
        _pickColorScript = GameObject.Find("Player").GetComponent<PickColor>();


    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();

        m_NewColor = new Color(m_Red, m_Green, m_Blue);
        _pickColorScript.SetColor(m_Red, m_Green, m_Blue);

        im.color = m_NewColor;

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        // Debug.Log("Y MIRROR HAND: " + transform.position.y);
        // Debug.Log("X MIRROR HAND: " + transform.position.x);


        PlatformerMove();


    }

    void ChangeColor()
    {
        if (transform.position.y > yZero + 1.5f && transform.position.y < yZero + 3f)
        {
            m_Green = (transform.position.x - xZero) * 0.08f;

        }
        else if (transform.position.y > yZero + 3f)
        {
            m_Red = (transform.position.x - xZero) * 0.08f;

        }
        else
        {
            m_Blue = (transform.position.x - xZero) * 0.08f;
            //change blue by factor of x pos
        }


    }


    void PlatformerMove()
    {

        // animator.SetFloat("ySpeed", yInput);
        // animator.SetFloat("xSpeed", Mathf.Abs(xInput));
        rb.velocity = new Vector2(_moveSpeed * xInput, yInput);


    }
}