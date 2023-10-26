using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class GiveOptionsOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    [SerializeField]
    private Text _playerText;
    [SerializeField]
    private Text _NPCText;
    private bool collided = false;
    private int _case;
    private int _choice;




    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private Button AButton;
    [SerializeField]
    private Button BButton;

    private bool runRoutine = true;

    public GameObject clicked_Object;

    private UIManager _uiManager;

    private Player playerScript;

    private void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _playerText.gameObject.SetActive(false);
        _panel.SetActive(false);


    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);
        _playerText.gameObject.transform.position = playerPos;
    }

    void OnMouseDown()
    {
        GiveOptions();
        Debug.Log("Mouse Down on Options");
    }

    public void GiveOptions()
    {

        if (runRoutine == true)
        {
            StartCoroutine("MoveThroughDialogue");
        }

    }
    private IEnumerator MoveThroughDialogue()
    {

        runRoutine = false;
        _uiManager.HideInventory();
        playerScript.MoveableFalse();

        //CLICK TO REVEAL PANEL
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _panel.SetActive(true);
        var waitForButton = new WaitForUIButtons(AButton, BButton);
        yield return waitForButton.Reset();
        // A 0 BUTTON PRESSED
        if (waitForButton.PressedButton == AButton)
        {
            // StartCoroutine("TalkThenPanel(0, 1, 1)");

            _panel.SetActive(false);
            _playerText.gameObject.SetActive(true);
            _playerText.text = "FIRST";
            Debug.Log("FIRST BUTTON PRESSED");
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            _playerText.gameObject.SetActive(false);
            runRoutine = true;
            _panel.SetActive(false);
            playerScript.MoveableTrue();
            yield break;

        }

        else
        {
            _panel.SetActive(false);
            _playerText.gameObject.SetActive(true);
            _playerText.text = "SECOND";
            Debug.Log("SECOND BUTTON PRESSED");
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            _playerText.gameObject.SetActive(false);
            runRoutine = true;
            _panel.SetActive(false);
            playerScript.MoveableTrue();
            yield break;



        }





    }

}





