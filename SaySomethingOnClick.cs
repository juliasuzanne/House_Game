using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaySomethingOnClick : MonoBehaviour
{
    private UIManager _uiManager;
    private Transform player;
    private Player playerScript;
    [SerializeField]
    private Text _playerText;
    [SerializeField]
    private string PlayerText;
    private GameManager _gameManager;



    // Start is called before the first frame update
    public void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = player.GetComponent<Player>();
        _playerText = player.GetChild(0).GetChild(0).GetComponent<Text>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();




    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        _playerText.gameObject.SetActive(true);
        _playerText.text = PlayerText;
        StartCoroutine("WaitForClick");


    }

    private IEnumerator WaitForClick()
    {
        yield return new WaitForSeconds(2f);
        _playerText.gameObject.SetActive(false);


    }



    void OnMouseUp()
    {

    }


}
