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






    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerText.gameObject.SetActive(true);
        _panel = this.gameObject.transform.GetChild(2).gameObject;
        _panel.SetActive(false);
        _NPCText.gameObject.SetActive(true);
        _AText = this.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>();
        _BText = this.gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>();

    }

    void Update()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        _playerText.gameObject.transform.position = playerPos;


    }

    public void AdvanceCases(int caseNum)

    {
        _case = _case + caseNum;
    }



    public void StartTalking()
    {
        if (runRoutine == true)
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
        runRoutine = false;

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

            //PLAYER SPEAKS OPTION 1
            _playerText.text = PlayerText_string[0];

            //PLAYER SPEAK SETUP
            //Debug.Log("A Button Pressed");
            // PlayerTalking();
            // NEED DISABLE PANEL 1 BUTTONS
            // _panel.SetActive(false);
            //TESTING ^^

            //WAIT FOR USER TO CLICK
            //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitForSeconds(0.5f);
            // NPC SPEAKS
            // NPCTalking();
            _NPCText.text = NPCText_string[1];
            //ENABLE PANEL
            // _panel.SetActive(true);
            //SET PANEL TEXT
            _AText.text = PlayerText_OptionA[1];
            _BText.text = PlayerText_OptionB[1];
            //WAIT FOR USER INPUT
            waitForButton = new WaitForUIButtons(AButton, BButton);
            yield return waitForButton.Reset();
            // A 1 BUTTON PRESSED
            if (waitForButton.PressedButton == AButton)
            {
                //PLAYER SPEAK SETUP
                //Debug.Log("A Button Pressed");
                // PlayerTalking();
                // NEED DISABLE PANEL 1 BUTTONS
                _panel.SetActive(false);
                //TESTING ^^

                //PLAYER SPEAKS OPTION 1
                PlayerTalking();
                _playerText.text = PlayerText_string[1];
                //WAIT FOR USER TO CLICK
                //yield return new WaitForSeconds(1.2f);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                //END OF THREAD
                // yield return new WaitForSeconds(0.1f);
                runRoutine = true;
                _playerText.gameObject.SetActive(false);

                yield break;

                //END OF THREAD


            }
            // B 1 BUTTON PRESSED
            else
            {
                //PLAYER SPEAK SETUP
                //Debug.Log("A Button Pressed");
                PlayerTalking();
                // NEED DISABLE PANEL 1 BUTTONS
                _panel.SetActive(false);
                //TESTING ^^

                //PLAYER SPEAKS OPTION 1
                _playerText.text = PlayerText_string[5];
                //WAIT FOR USER TO CLICK
                //yield return new WaitForSeconds(1.2f);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                // NPC SPEAKS
                NPCTalking();
                _NPCText.text = NPCText_string[3];
                //ENABLE PANEL
                _panel.SetActive(true);
                //SET PANEL TEXT
                _AText.text = PlayerText_OptionA[3];
                _BText.text = PlayerText_OptionB[3];
                //WAIT FOR USER INPUT
                yield break;
            }


        }
        else
        // B 0 BUTTON PRESSED
        {
            PlayerTalking();
            _playerText.text = PlayerText_string[4];
            _NPCText.gameObject.SetActive(false);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        }





    }




}
//     {
//         for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
//         {
//             dialogueText.text = dialogueObject.dialogueLines[i].dialogue;

//             //The following line of code makes it so that the for loop is paused until the user clicks the left mouse button.
//             yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
//             //The following line of code makes the coroutine wait for a frame so as the next WaitUntil is not skipped
//             yield return null;
//         }
//         dialogueBox.SetActive(false);
//     }
//         switch (_case)
//         {
//             case 0:
//                 _playerText.gameObject.SetActive(true);
//                 _NPCText.gameObject.SetActive(false);
//                 _playerText.text = "Hello";
//                 _AText.text = "Testing";
//                 _BText.text = "Testing 2";
//                 this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
//                 break;
//             case 1:
//                 _playerText.gameObject.SetActive(false);
//                 _NPCText.gameObject.SetActive(true); _NPCText.text = "Hello";
//                 break;
//             case 2:
//                 _NPCText.text = "...";
//                 _playerText.gameObject.SetActive(true);
//                 _NPCText.gameObject.SetActive(false); _playerText.text = "This is my first time here.";
//                 break;
//             case 3:
//                 _playerText.gameObject.SetActive(false);
//                 _NPCText.gameObject.SetActive(true); _NPCText.text = "Do you need help?";
//                 _playerText.text = "...";
//                 break;
//             case 4:
//                 _playerText.gameObject.SetActive(false);
//                 _NPCText.gameObject.SetActive(false);
//                 this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

//                 _case = -1;

//                 break;

//         }

// Debug.Log("Case: " + +_case);
//     }








