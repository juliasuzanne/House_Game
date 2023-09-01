using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    [SerializeField]
    private Text _playerText;
    [SerializeField]
    private Text _NPCText;
    private int _case;




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerText.gameObject.SetActive(true);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);


    }

    void Update()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        _playerText.gameObject.transform.position = playerPos;


    }

    public void AdvanceCases()

    {
        _case = _case + 1;

    }


    public void StartTalking()
    {


        switch (_case)
        {
            case 0:
                _playerText.gameObject.SetActive(true);
                _NPCText.gameObject.SetActive(false);
                _playerText.text = "Hello";
                this.gameObject.transform.GetChild(2).gameObject.SetActive(true);


                break;
            case 1:
                _playerText.gameObject.SetActive(false);
                _NPCText.gameObject.SetActive(true); _NPCText.text = "Hello";
                break;
            case 2:
                _NPCText.text = "...";
                _playerText.gameObject.SetActive(true);
                _NPCText.gameObject.SetActive(false); _playerText.text = "This is my first time here.";
                break;
            case 3:
                _playerText.gameObject.SetActive(false);
                _NPCText.gameObject.SetActive(true); _NPCText.text = "Do you need help?";
                _playerText.text = "...";
                break;
            case 4:
                _playerText.gameObject.SetActive(false);
                _NPCText.gameObject.SetActive(false);
                this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

                _case = -1;

                break;

        }

        Debug.Log("Case: " + +_case);
    }








}


