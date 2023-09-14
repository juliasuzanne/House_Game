using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;





public class InventoryButton : MonoBehaviour
{

    [SerializeField]
    private string _name;

    [SerializeField]
    private Image _image;

    private Inventory inventory;
    private UIManager _uiManager;

    private GameObject dialogue;
    private Dialog _dialogueScript;

    private Text player_text;

    private bool moving = false;
    private bool can_pickup = true;

    private string collisionGameobjectName = "";


    [SerializeField]
    private Vector3 startingPoint;

    private Vector3 mousePosition;

    [SerializeField]
    private bool consumeable = false;

    private float offsetX, offsetY;
    public static bool mouseButtonReleased = true;

    private TextMeshProUGUI description_object;
    private bool current_so;
    private bool collided = true;


    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        dialogue = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0).gameObject;
        _dialogueScript = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(0).GetComponent<Dialog>();
        player_text = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Text>();
        description_object = transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();

        if (_uiManager == null)
        {
            Debug.LogError("The UIManager is NULL");
        }
    }

    public void GetCollided()
    {
        _dialogueScript.CollidedIsTrue();
        collided = true;
    }

    void Update()
    {

        if (moving == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
            if (transform.position == startingPoint)
            {
                transform.position = startingPoint;
                moving = false;
            }

        }

        Debug.Log("pickup is " + can_pickup);
        // Debug.Log(_name + " " + transform.position);

    }

    void OnMouseDown()
    {
        if (moving == true)
        {

            transform.position = startingPoint;
            moving = false;
            can_pickup = false;
            StartCoroutine("CanPickup");

            if (collisionGameobjectName == "yarn")
            {
                dialogue.SetActive(true);
                StartCoroutine("YarnCollision");

            }
            else if (collided == true)
            {
                dialogue.SetActive(true);
                StartCoroutine("OtherCollision");


            }
        }

        else if (moving == false && current_so == true && can_pickup == true)
        {
            moving = true;

        }
    }


    IEnumerator CanPickup()
    {
        transform.position = startingPoint;
        yield return new WaitForSeconds(0.5f);
        can_pickup = true;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (moving == true)
        {
            _dialogueScript.CollidedIsTrue();
            collided = true;
            collisionGameobjectName = collision.gameObject.name;
            description_object.enabled = true;
            description_object.text = "Use " + gameObject.name + " with " + collisionGameobjectName;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        _dialogueScript.CollidedIsFalse();
        collided = false;
        collisionGameobjectName = null;
        description_object.enabled = false;
        description_object.text = "";

    }



    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     string thisGameobjectName;
    //     thisGameobjectName = gameObject.name;
    //     collisionGameobjectName = collision.gameObject.name;

    //     //create text child of transforms that will be activated with coroutine to show up for a certain amount of time

    //     if (collisionGameobjectName == "yarn")
    //     {
    //         dialogue.SetActive(true);

    //     }


    //     // Debug.Log("This: " + thisGameobjectName + "collision with :" + collisionGameobjectName);
    // }



    IEnumerator YarnCollision()
    {
        if (consumeable == true)
        {
            can_pickup = true;
            _uiManager.MakeInventoryUIShadow(0);

        }
        player_text.text = "yarn collision";
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(false);

    }

    IEnumerator OtherCollision()
    {

        player_text.text = "That doesn't seem to have an effect";
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(false);

    }


    public void UseLeaf()
    {
        current_so = _uiManager.so.leaf;

        if (_name == "leaf" && _uiManager.so.leaf == true && can_pickup == true)
        {
            can_pickup = false;
            moving = true;
        }


    }

    public void UseRock()
    {

        current_so = _uiManager.so.rock;

        if (_name == "rock" && _uiManager.so.rock == true && can_pickup == true)
        {
            can_pickup = false;
            moving = true;

        }

    }

    public void UseBand()
    {
        current_so = _uiManager.so.band;


        if (_name == "band" && _uiManager.so.band == true && can_pickup == true)
        {
            can_pickup = false;
            moving = true;

        }

    }

}

