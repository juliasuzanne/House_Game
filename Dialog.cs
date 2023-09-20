using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class Dialog : MonoBehaviour
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

    private void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _playerText.gameObject.SetActive(true);
        _panel = this.gameObject.transform.GetChild(2).gameObject;
        _panel.SetActive(false);
        _NPCText.gameObject.SetActive(true);
        _AText = this.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>();
        _BText = this.gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>();


    }

    void Update()
    {
        Vector2 playerPos = new Vector2(player.position.x + 1.8f, player.position.y + 2.5f);
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

    private void PlayerTalking()
    {
        _playerText.gameObject.SetActive(true);
        _NPCText.gameObject.SetActive(false);

    }
    private void NPCTalking()
    {
        _playerText.gameObject.SetActive(false);
        _NPCText.gameObject.SetActive(true);

    }

    private IEnumerator MoveThroughDialogue()
    {
        playerScript.MoveableFalse();
        NPCTalking();
        runRoutine = false;
        _uiManager.HideInventory();
        // NPC 0
        _NPCText.text = NPCText_string[0];
        // PANEL 0 OPTIONS
        _AText.text = PlayerText_OptionA[0];
        _BText.text = PlayerText_OptionB[0];
        //CLICK TO REVEAL PANEL
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _panel.SetActive(true);
        var waitForButton = new WaitForUIButtons(AButton, BButton);
        yield return waitForButton.Reset();
        // A 0 BUTTON PRESSED
        if (waitForButton.PressedButton == AButton)
        {
            // StartCoroutine("TalkThenPanel(0, 1, 1)");
            PlayerTalking();
            _panel.SetActive(false);
            _playerText.text = PlayerText_string[0];
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            // NPC 3
            NPCTalking();
            _NPCText.text = NPCText_string[1];
            _panel.SetActive(true);
            _AText.text = PlayerText_OptionA[1];
            _BText.text = PlayerText_OptionB[1];
            waitForButton = new WaitForUIButtons(AButton, BButton);
            yield return waitForButton.Reset();


            // A 1 BUTTON PRESSED
            if (waitForButton.PressedButton == AButton)
            {
                // StartCoroutine("TalkThenPlayerEndConvo(1)");
                // //END OF THREAD
                PlayerTalking();                                                        //ENABLE PLAYER SPEECH, DISABLE NPC SPEECH
                _panel.SetActive(false);                                                 //DISABLE PANEL
                _playerText.text = PlayerText_string[1];                           //SET PLAYER TEXT FROM ARRAY
                yield return new WaitForSeconds(2.0f);
                _playerText.gameObject.SetActive(false);
                runRoutine = true;                                                      //RESET TO BE ABLE TO RESTART CONVO
                _panel.SetActive(false);
                playerScript.MoveableTrue();
                yield break;


            }
            // B 1 BUTTON PRESSED
            else
            {
                //PLAYER STRING 5
                // StartCoroutine("TalkThenPanel(5, 3, 3)");
                PlayerTalking();
                _panel.SetActive(false);
                _playerText.text = PlayerText_string[5];
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                // NPC 3
                NPCTalking();
                _NPCText.text = NPCText_string[3];
                _panel.SetActive(true);
                _AText.text = PlayerText_OptionA[3];
                _BText.text = PlayerText_OptionB[3];
                waitForButton = new WaitForUIButtons(AButton, BButton);
                yield return waitForButton.Reset();

                // A 3 BUTTON PRESSED
                if (waitForButton.PressedButton == AButton)
                {
                    // StartCoroutine("TalkThenEndConvo(3, 4)");                                         //PLAYER, NPC
                    PlayerTalking();                                                        //ENABLE PLAYER SPEECH, DISABLE NPC SPEECH
                    _panel.SetActive(false);                                                 //DISABLE PANEL
                    _playerText.text = PlayerText_string[3];                           //SET PLAYER TEXT FROM ARRAY
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                    NPCTalking();
                    _NPCText.text = NPCText_string[4];
                    yield return new WaitForSeconds(2.0f);

                    runRoutine = true;                                                      //RESET TO BE ABLE TO RESTART CONVO
                    _playerText.gameObject.SetActive(false);                                 //HIDE PLAYER BUBBLE
                    _NPCText.gameObject.SetActive(false);                                 //HIDE PLAYER BUBBLE
                    _panel.SetActive(false);
                    playerScript.MoveableTrue();

                    yield break;

                }
                // B 3 BUTTON PRESSED
                else
                {
                    // StartCoroutine("TalkThenEndConvo(7, 5)");                                             //PLAYER, NPC, PANEL
                    PlayerTalking();                                                        //ENABLE PLAYER SPEECH, DISABLE NPC SPEECH
                    _panel.SetActive(false);                                                 //DISABLE PANEL
                    _playerText.text = PlayerText_string[7];                           //SET PLAYER TEXT FROM ARRAY
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                    NPCTalking();
                    _NPCText.text = NPCText_string[5];
                    yield return new WaitForSeconds(2.0f);
                    runRoutine = true;                                                      //RESET TO BE ABLE TO RESTART CONVO
                    _playerText.gameObject.SetActive(false);                                 //HIDE PLAYER BUBBLE
                    _NPCText.gameObject.SetActive(false);
                    _panel.SetActive(false);
                    playerScript.MoveableTrue();

                    yield break;
                }

            }


        }
        else
        // B 0 BUTTON PRESSED
        {
            // StartCoroutine("TalkThenPanel(4, 2, 2)");

            PlayerTalking();
            _panel.SetActive(false);
            _playerText.text = PlayerText_string[4];
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            // NPC 3
            NPCTalking();
            _NPCText.text = NPCText_string[2];
            _panel.SetActive(true);
            _AText.text = PlayerText_OptionA[2];
            _BText.text = PlayerText_OptionB[2];
            waitForButton = new WaitForUIButtons(AButton, BButton);
            yield return waitForButton.Reset();

            // A 2 BUTTON PRESSED
            if (waitForButton.PressedButton == AButton)
            {
                // StartCoroutine(TalkThenNPCEndConvo(2, 4));
                PlayerTalking();                                                        //ENABLE PLAYER SPEECH, DISABLE NPC SPEECH
                _panel.SetActive(false);                                                 //DISABLE PANEL
                _playerText.text = PlayerText_string[2];                           //SET PLAYER TEXT FROM ARRAY
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                NPCTalking();
                _NPCText.text = NPCText_string[4];

                yield return new WaitForSeconds(2.0f);

                _playerText.gameObject.SetActive(false);                                 //HIDE PLAYER BUBBLE
                _NPCText.gameObject.SetActive(false);                                 //HIDE NPC BUBBLE
                _panel.SetActive(false);
                runRoutine = true;                                                      //RESET TO BE ABLE TO RESTART CONVO
                playerScript.MoveableTrue();

                yield break;
            }
            // B 2 BUTTON PRESSED
            else
            {
                // StartCoroutine(TalkThenNPCEndConvo(6, 4));
                PlayerTalking();                                                        //ENABLE PLAYER SPEECH, DISABLE NPC SPEECH
                _panel.SetActive(false);                                                 //DISABLE PANEL
                _playerText.text = PlayerText_string[6];                           //SET PLAYER TEXT FROM ARRAY
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                NPCTalking();
                _NPCText.text = NPCText_string[4];
                yield return new WaitForSeconds(2.0f);

                runRoutine = true;                                                      //RESET TO BE ABLE TO RESTART CONVO
                _playerText.gameObject.SetActive(false);                                 //HIDE PLAYER BUBBLE
                _NPCText.gameObject.SetActive(false);                                 //HIDE NPC BUBBLE
                _panel.SetActive(false);
                playerScript.MoveableTrue();

                yield break;
            }

        }





    }




}