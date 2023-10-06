using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class Conversation : MonoBehaviour
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
    private TMPro.TextMeshProUGUI _AText;
    [SerializeField]
    private TMPro.TextMeshProUGUI _BText;
    [SerializeField]
    private string[] NPCText_string;
    [SerializeField]
    private string[] PlayerText_string;
    [SerializeField]
    private string[] PlayerText_OptionA;
    [SerializeField]
    private string[] PlayerText_OptionB;
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

    public void CollidedIsFalse()
    {
        collided = false;
    }

    public void CollidedIsTrue()
    {
        collided = true;
    }


    public void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _playerText.gameObject.SetActive(false);
        _panel = this.gameObject.transform.GetChild(2).gameObject;
        _panel.SetActive(false);
        _NPCText.gameObject.SetActive(true);
        _AText = this.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>();
        _BText = this.gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>();


    }

    void Update()
    {

        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);
        _playerText.gameObject.transform.position = playerPos;

    }

    public void AdvanceCases(int caseNum)

    {
        _case = _case + caseNum;
    }



    public void StartTalking()
    {

        if (runRoutine == true && collided == false)
        {
            StartCoroutine("MoveThroughDialogue");
        }

    }

    public void PlayerTalking()
    {
        _playerText.gameObject.SetActive(true);
        _NPCText.gameObject.SetActive(false);

    }
    private void NPCTalking()
    {
        _playerText.gameObject.SetActive(false);
        _NPCText.gameObject.SetActive(true);

    }

    private void NPCTalkThenPanel(int NPCstring, int AString, int BString)
    {
        NPCTalking();
        _NPCText.text = NPCText_string[NPCstring];
        _panel.SetActive(true);
        _AText.text = PlayerText_OptionA[AString];
        _BText.text = PlayerText_OptionB[BString];
    }

    private void PlayerSaySomething(int PlayerString)
    {
        PlayerTalking();
        _panel.SetActive(false);
        _playerText.text = PlayerText_string[PlayerString];
    }

    private void EndConversation()
    {
        _playerText.gameObject.SetActive(false);
        runRoutine = true;
        _NPCText.gameObject.SetActive(false);
        _panel.SetActive(false);
        playerScript.MoveableTrue();
    }

    private IEnumerator MoveThroughDialogue()
    {
        //setup for conversation
        NPCTalking();
        runRoutine = false;
        _uiManager.HideInventory();
        playerScript.MoveableFalse();
        _NPCText.text = NPCText_string[0];
        _AText.text = PlayerText_OptionA[0];
        _BText.text = PlayerText_OptionB[0];
        //WAIT FOR CLICK, REVEAL PANEL
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _panel.SetActive(true);

        // A 0 BUTTON PRESSED
        var waitForButton = new WaitForUIButtons(AButton, BButton);
        yield return waitForButton.Reset();
        if (waitForButton.PressedButton == AButton)
        {
            PlayerSaySomething(0);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            NPCTalkThenPanel(1, 1, 1);
            yield return waitForButton.Reset();

            // A 1 BUTTON PRESSED
            if (waitForButton.PressedButton == AButton)
            {
                PlayerSaySomething(1);                         //SET PLAYER TEXT FROM ARRAY
                yield return new WaitForSeconds(2.0f);
                EndConversation();
                yield break;

            }
            // B 1 BUTTON PRESSED
            else
            {
                PlayerSaySomething(5);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                NPCTalkThenPanel(3, 3, 3);
                waitForButton = new WaitForUIButtons(AButton, BButton);
                yield return waitForButton.Reset();

                if (waitForButton.PressedButton == AButton)
                {
                    PlayerSaySomething(3);                       //SET PLAYER TEXT FROM ARRAY
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                    NPCTalking();
                    _NPCText.text = NPCText_string[4];
                    yield return new WaitForSeconds(2.0f);
                    EndConversation();
                    yield break;

                }
                // B 3 BUTTON PRESSED
                else
                {

                    PlayerSaySomething(7);
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    NPCTalking();
                    _NPCText.text = NPCText_string[5];
                    yield return new WaitForSeconds(2.0f);
                    EndConversation();
                    yield break;
                }

            }


        }
        else
        // B 0 BUTTON PRESSED
        {
            PlayerSaySomething(4);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            NPCTalkThenPanel(2, 2, 2);
            waitForButton = new WaitForUIButtons(AButton, BButton);
            yield return waitForButton.Reset();
            if (waitForButton.PressedButton == AButton)
            {
                PlayerSaySomething(2);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                NPCTalking();
                _NPCText.text = NPCText_string[4];
                yield return new WaitForSeconds(2.0f);
                EndConversation();
                yield break;
            }
            // B 2 BUTTON PRESSED
            else
            {
                PlayerSaySomething(6);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                NPCTalking();
                _NPCText.text = NPCText_string[4];
                EndConversation();
                yield break;
            }

        }


    }

}