using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    private Hand player;
    private GameObject platform;
    private string text;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Hand>();
        platform = GameObject.Find("Platform");
        text = transform.GetChild(0).GetComponent<Text>().text;

    }

    public void StepForward()
    {
        switch (count)
        {
            case 0:
                text = "What am I doing here?";
                count = 1;
                break;
            case 1:
                text = "I don't remember anything.";
                count = 2;
                break;
            case 2:
                text = "Is that me?";
                count = 3;
                break;
            case 3:
                transform.gameObject.SetActive(false);
                platform.SetActive(false);
                player.UseGravity();
                break;

        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
