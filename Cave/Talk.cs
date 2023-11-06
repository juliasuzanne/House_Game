using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    private Hand player;
    private GameObject platform;
    private string text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Hand>();
        platform = GameObject.Find("Platform");
        text = transform.GetChild(0).GetComponent<Text>().text;

    }

    public void StepForward()
    {

        transform.gameObject.SetActive(false);
        platform.SetActive(false);
        player.UseGravity();

    }


    // Update is called once per frame
    void Update()
    {

    }
}
